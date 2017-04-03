﻿using UnityEngine;
using System.Collections;

using uAdventure.Core;
using System;

namespace uAdventure.Geo
{
    public class MapElement : Documented, HasTargetId, ICloneable
    {
        private string targetId;
        private string documentation;
        
        public int Layer { get; set; }

        public Conditions Conditions { get; set; }

        public MapElement() : this("") { }

        public MapElement(string targetId)
        {
            this.targetId = targetId;
            Conditions = new Conditions();
        }
        
        public string getTargetId()
        {
            return targetId;
        }

        public void setTargetId(string id)
        {
            this.targetId = id;
        }

        public string getDocumentation()
        {
            return documentation;
        }

        public void setDocumentation(string documentation)
        {
            this.documentation = documentation;
        }

        public object Clone()
        {
            var clone = MemberwiseClone() as MapElement;
            clone.Conditions = Conditions.Clone() as Conditions;

            return clone;
        }
    }
}


