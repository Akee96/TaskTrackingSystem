﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTS.Data.Common;
using TTS.Models;

namespace TTS.Data
{
    public class TemplateDL : DataAccessBase
    {
        public Template AddTemplateDetails(Inititiative inititiative)
        {
            Func<SqlCommand, Template> injector = cmd =>
            {
                //cmd.Parameters.Add("@GroupId", SqlDbType.Int).Value = inititiative.Group.Id;
                cmd.Parameters.Add("@WorkGroupResponsibility", SqlDbType.VarChar).Value = inititiative.WorkGroupResponsibility;
                cmd.Parameters.Add("@CoreGroupResponsibility", SqlDbType.VarChar).Value = inititiative.CoreGroupResponsibility;
                cmd.Parameters.Add("@InitiativeWhyNotCarried", SqlDbType.VarChar).Value = inititiative.InitiativeWhyNotCarried;
                cmd.Parameters.Add("@ProjectedDOC", SqlDbType.VarChar).Value = inititiative.ProjectedDOC;
                cmd.Parameters.Add("@ProjectedNetRevenue", SqlDbType.VarChar).Value = inititiative.ProjectedNetRevenue;
                cmd.Parameters.Add("@ProjectedContribution", SqlDbType.VarChar).Value = inititiative.ProjectedContribution;
                cmd.Parameters.Add("@AchievedContribution", SqlDbType.VarChar).Value = inititiative.AchievedContribution;
                cmd.Parameters.Add("@ExpectedAchievedContribution", SqlDbType.VarChar).Value = inititiative.ExpectedAchievedContribution;
                cmd.Parameters.Add("@GAP", SqlDbType.VarChar).Value = inititiative.GAP;

                Template template = new Template();
                SqlDataReader rdr = cmd.ExecuteReader();
                if ((rdr.Read()))
                {
                    template.Id = Convert.ToInt32(rdr["id"]);
                }
                

                return template;
            };
            return Data.SqlSpExecute("sp_InsertInitiative", injector);
        }

        public List<Template> GetTemplateDetailsByName(Group group)
        {
            Func<SqlCommand, List<Template>> injector = cmd =>
            {
                cmd.Parameters.Add("@TemplateName", SqlDbType.VarChar).Value = group.Template.Name;
                cmd.Parameters.Add("@TemplateRecordId", SqlDbType.VarChar).Value = group.Template.Id.ToString();

                List<Template> templates = new List<Template>();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        var template = new Template
                        {
                            Item = rdr["Item"].ToString(),
                            Value = rdr["Value"].ToString(),

                            //IsActive = (bool)rdr["IsActive"],
                            //CreatedUser = rdr["CreatedUser"].ToString(),
                            //CreatedDate = (DateTime)rdr["CreatedDate"]
                        };
                        templates.Add(template);
                    }
                }

                return templates;
            };
            return Data.SqlSpExecute("sp_GetTemplateDetailsByName", injector);
        }
    }
}