using OSGeo.GDAL;
using OSGeo.OGR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KML2SHPbyGDAL.App_Code
{
    public class VectorFile
    {
        public static void WriteVectorFile(string strVectorFile)
        {
            Gdal.AllRegister();
            // 为了支持中文路径，请添加下面这句代码  
            OSGeo.GDAL.Gdal.SetConfigOption("GDAL_FILENAME_IS_UTF8", "NO");
            // 为了使属性表字段支持中文，请添加下面这句  
            OSGeo.GDAL.Gdal.SetConfigOption("SHAPE_ENCODING", "");

            //string strVectorFile = @"C:\Users\Administrator\Desktop\shptest\TestPolygon.shp";

            // 注册所有的驱动  
            Ogr.RegisterAll();

            //创建数据，这里以创建ESRI的shp文件为例  
            string strDriverName = "ESRI Shapefile";
            OSGeo.OGR.Driver oDriver = Ogr.GetDriverByName(strDriverName);
            if (oDriver == null)
            {
                MessageBox.Show("%s 驱动不可用！\n", strVectorFile);
                return;
            }

            // 创建数据源  
            DataSource oDS = oDriver.CreateDataSource(strVectorFile, null);
            if (oDS == null)
            {
                MessageBox.Show("创建矢量文件【%s】失败！\n", strVectorFile);
                return;
            }

            // 创建图层，创建一个多边形图层，这里没有指定空间参考，如果需要的话，需要在这里进行指定  
            Layer oLayer = oDS.CreateLayer("TestPolygon", null, wkbGeometryType.wkbPolygon, null);
            if (oLayer == null)
            {
                MessageBox.Show("图层创建失败！\n");
                return;
            }

            // 下面创建属性表
            // 先创建一个叫FieldID的整型属性
            FieldDefn oFieldID = new FieldDefn("FieldID", FieldType.OFTInteger);
            oLayer.CreateField(oFieldID, 1);

            // 再创建一个叫FeatureName的字符型属性，字符长度为50
            FieldDefn oFieldName = new FieldDefn("FieldName", FieldType.OFTString);
            oFieldName.SetWidth(100);
            oLayer.CreateField(oFieldName, 1);

            FeatureDefn oDefn = oLayer.GetLayerDefn();

            // 创建三角形要素
            Feature oFeatureTriangle = new Feature(oDefn);
            oFeatureTriangle.SetField(0, 0);
            oFeatureTriangle.SetField(1, "三角形");
            Geometry geomTriangle = Geometry.CreateFromWkt("POLYGON ((0 0,20 0,10 15,0 0))");
            oFeatureTriangle.SetGeometry(geomTriangle);

            oLayer.CreateFeature(oFeatureTriangle);

            // 创建矩形要素
            Feature oFeatureRectangle = new Feature(oDefn);
            oFeatureRectangle.SetField(0, 1);
            oFeatureRectangle.SetField(1, "矩形");
            Geometry geomRectangle = Geometry.CreateFromWkt("POLYGON ((30 0,60 0,60 30,30 30,30 0))");
            oFeatureRectangle.SetGeometry(geomRectangle);

            oLayer.CreateFeature(oFeatureRectangle);

            // 创建岛要素
            Feature oFeatureHole = new Feature(oDefn);
            oFeatureHole.SetField(0, 1);
            oFeatureHole.SetField(1, "环岛测试");
            //Geometry geomWYX = Geometry.CreateFromWkt("POLYGON ((30 0,60 0,60 30,30 30,30 0))");
            OSGeo.OGR.Geometry outGeo = new OSGeo.OGR.Geometry(OSGeo.OGR.wkbGeometryType.wkbLinearRing);
            outGeo.AddPoint(40, -30, 0);
            outGeo.AddPoint(60, -30, 0);
            outGeo.AddPoint(60, -10, 0);
            outGeo.AddPoint(40, -10, 0);

            OSGeo.OGR.Geometry inGeo = new OSGeo.OGR.Geometry(OSGeo.OGR.wkbGeometryType.wkbLinearRing);
            inGeo.AddPoint(45, -25, 0);
            inGeo.AddPoint(55, -25, 0);
            inGeo.AddPoint(55, -15, 0);
            inGeo.AddPoint(45, -15, 0);

            OSGeo.OGR.Geometry geo = new OSGeo.OGR.Geometry(OSGeo.OGR.wkbGeometryType.wkbPolygon);
            geo.AddGeometryDirectly(outGeo);
            geo.AddGeometryDirectly(inGeo);
            oFeatureHole.SetGeometry(geo);
            oLayer.CreateFeature(oFeatureHole);

            // 创建Multi要素
            Feature oFeatureMulty = new Feature(oDefn);
            oFeatureMulty.SetField(0, 1);
            oFeatureMulty.SetField(1, "MultyPart测试");
            OSGeo.OGR.Geometry geo1 = new OSGeo.OGR.Geometry(OSGeo.OGR.wkbGeometryType.wkbLinearRing);
            geo1.AddPoint(25, -10, 0);
            geo1.AddPoint(5, -10, 0);
            geo1.AddPoint(5, -30, 0);
            geo1.AddPoint(25, -30, 0);
            OSGeo.OGR.Geometry poly1 = new Geometry(wkbGeometryType.wkbPolygon);
            poly1.AddGeometryDirectly(geo1);

            OSGeo.OGR.Geometry geo2 = new OSGeo.OGR.Geometry(OSGeo.OGR.wkbGeometryType.wkbLinearRing);
            geo2.AddPoint(0, -15, 0);
            geo2.AddPoint(-5, -15, 0);
            geo2.AddPoint(-5, -20, 0);
            geo2.AddPoint(0, -20, 0);

            OSGeo.OGR.Geometry poly2 = new Geometry(wkbGeometryType.wkbPolygon);
            poly2.AddGeometryDirectly(geo2);

            OSGeo.OGR.Geometry geoMulty = new OSGeo.OGR.Geometry(OSGeo.OGR.wkbGeometryType.wkbMultiPolygon);
            geoMulty.AddGeometryDirectly(poly1);
            geoMulty.AddGeometryDirectly(poly2);
            oFeatureMulty.SetGeometry(geoMulty);

            oLayer.CreateFeature(oFeatureMulty);

            MessageBox.Show("\n数据集创建完成！\n");
        }  

    }
}
