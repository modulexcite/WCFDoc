﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NAnt.Core;
using NAnt.Core.Attributes;
using WcfDoc.Engine;

namespace WcfDoc.NAnt
{
    [TaskName("wcf-doc")]
    public class Task : global::NAnt.Core.Task
    {
        // ────────────────────────── Task Parameters ──────────────────────────

        [TaskAttribute("assemblies", Required = true)]
        public string Assemblies { get; set; }

        [TaskAttribute("output", Required = true)]
        public string Output { get; set; }

        [TaskAttribute("stylesheet", Required = false)]
        public string Stylesheet { get; set; }

        [TaskAttribute("mergeFiles", Required = false)]
        public string MergeFiles { get; set; }

        [TaskAttribute("websitePath", Required = false)]
        public string WebsitePath { get; set; }

        [TaskAttribute("config", Required = false)]
        public string Config { get; set; }

        [TaskAttribute("xmlComments", Required = false)]
        public string XmlComments { get; set; }
        
        // ────────────────────────── Overriden Members ──────────────────────────

        protected override void ExecuteTask()
        {
            try
            {
                new Generator(
                    new Context(
                    Assemblies != null ? Assemblies.Split(new char[] {'|'}) : null, 
                    Output, 
                    Stylesheet,  
                    MergeFiles != null ? MergeFiles.Split(new char[] {'|'}) : null,
                    WebsitePath,
                    Config,
                    XmlComments != null ? XmlComments.Split(new char[] {'|'}) : null
                    )).Generate();
            }
            catch (Exception exception)
            {
                throw new BuildException("An error occured in Wcf Doc.", exception);
            }
        }
    }
}
