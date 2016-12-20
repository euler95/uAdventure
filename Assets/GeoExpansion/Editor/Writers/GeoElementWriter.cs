﻿using UnityEngine;
using System.Collections;
using uAdventure.Geo;
using System;
using System.Xml;
using System.Collections.Generic;

namespace uAdventure.Editor
{
    [DOMWriter(typeof(GeoElement))]
    public class GeoElementWriter : ParametrizedDOMWriter
    {
        protected override void FillNode(XmlNode node, object target, params IDOMWriterParam[] options)
        {
            var geoelement = target as GeoElement;
            var doc = Writer.GetDoc();

            AddChild(node, "id", geoelement.Id);
            AddChild(node, "name", geoelement.Name);
            AddChild(node, "description", geoelement.FullDescription);
            AddChild(node, "brief-description", geoelement.BriefDescription);
            AddChild(node, "detailed-description", geoelement.DetailedDescription);
            DumpGML(node, "geometry", geoelement.Geometry);
            AddChild(node, "detailed-description", geoelement.Influence.ToString());
            var actions = doc.CreateElement("actions");
            node.AppendChild(actions);
            DOMWriterUtility.DOMWrite(actions, geoelement.Actions);
        }

        private void AddChild(XmlNode parent, string name, string content)
        {
            var doc = Writer.GetDoc();
            var elem = doc.CreateElement(name);
            elem.InnerText = content;
            parent.AppendChild(elem);
        }

        private void DumpGML(XmlNode parent, string name, GMLGeometry content)
        {
            var doc = Writer.GetDoc();
            // base element
            var elem = doc.CreateElement(name);
            parent.AppendChild(elem);

            // Dump geometry type
            XmlNode gmlElement;
            switch (content.Type)
            {
                case GMLGeometry.GeometryType.Point:
                    gmlElement = doc.CreateElement("gml:Point");
                    DumpPosList(gmlElement, content.Points);
                    break;
                case GMLGeometry.GeometryType.LineString:
                    gmlElement = doc.CreateElement("gml:LineString");
                    DumpPosList(gmlElement, content.Points);
                    break;
                default:
                case GMLGeometry.GeometryType.Polygon:
                    gmlElement = doc.CreateElement("gml:Polygon");
                    var exterior = doc.CreateElement("gml:exterior");
                    gmlElement.AppendChild(exterior);
                    var linearRing = doc.CreateElement("gml:LinearRing");
                    exterior.AppendChild(linearRing);
                    DumpPosList(linearRing, content.Points);
                    break;
            }
            elem.AppendChild(gmlElement);
        }

        private void DumpPosList(XmlNode parent, List<Vector2d> points)
        {

            var doc = Writer.GetDoc();
            // base element
            var elem = doc.CreateElement(points.Count > 1 ? "gml:posList" : "gml:pos");
            parent.AppendChild(elem);

            elem.InnerText = String.Join(" ", points.ConvertAll(p => p.x + " " + p.y).ToArray());
        }

        protected override string GetElementNameFor(object target)
        {
            return "geoelement";
        }
    }
}

