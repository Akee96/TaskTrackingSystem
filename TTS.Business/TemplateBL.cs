﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTS.Data;
using TTS.Models;

namespace TTS.Business
{
    public class TemplateBL
    {
        private TemplateDL templateDL = new TemplateDL();
        public Template AddTemplateDetails(Inititiative inititiative,Item item)
        {
            return templateDL.AddTemplateDetails(inititiative, item);
        }

        public bool UpdateTemplateDetails(Template template, Inititiative inititiative)
        {
            return templateDL.UpdateTemplateDetails(template, inititiative);
        }

        public List<Template> GetTemplateDetailsByName(Group group)
        {
            return templateDL.GetTemplateDetailsByName(group);
        }
    }
}
