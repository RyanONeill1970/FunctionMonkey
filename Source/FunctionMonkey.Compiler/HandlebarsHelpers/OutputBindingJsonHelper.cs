﻿using System;
using System.IO;
using FunctionMonkey.Abstractions.Builders.Model;
using FunctionMonkey.Compiler.Implementation;
using HandlebarsDotNet;

namespace FunctionMonkey.Compiler.HandlebarsHelpers
{
    internal static class OutputBindingJsonHelper
    {
        public static void Register()
        {
            Handlebars.RegisterHelper("outputTriggerJson", (writer, context, parameters) => HelperFunction(writer, context));
        }

        private static void HelperFunction(TextWriter writer, dynamic context)
        {
            if (context is AbstractFunctionDefinition functionDefinition)
            {
                if (functionDefinition.OutputBinding == null)
                {
                    return;
                }

                WriteTemplate(writer, functionDefinition);
            }
        }

        private static void WriteTemplate(TextWriter writer, AbstractFunctionDefinition functionDefinition)
        {
            TemplateProvider templateProvider = new TemplateProvider();
            string templateSource = templateProvider.GetJsonOutputParameterTemplate(functionDefinition.OutputBinding);
            Func<object, string> template = Handlebars.Compile(templateSource);

            string output = template(functionDefinition.OutputBinding);
            writer.Write(",");
            writer.Write(output);
        }
    }
}
