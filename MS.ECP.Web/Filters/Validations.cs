using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MS.ECP.Utility;

namespace MS.ECP.Web.Filters
{

    public class RequiredTrueAttribute : RequiredAttribute, IClientValidatable
    {
        private const string Jsadapt = "requiredtrue";

        public override bool IsValid(object value)
        {
            return value != null && (bool) value;
        }

        // Implement IClientValidatable for client side Validation 
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata,
            ControllerContext context)
        {
            return new[]
            {
                new ModelClientValidationRule {ValidationType = Jsadapt, ErrorMessage = this.ErrorMessage}
            };
        }
    }

    public class RequiredMessageAttribute : ValidationAttribute, IClientValidatable
    {

        private readonly string _innertext;
        private string _innertextfomate;

        public RequiredMessageAttribute(string innertext, string tiperroer = "{0}不能为空")
            : base(tiperroer)
        {
            _innertext = innertext;
        }

        public override bool IsValid(object value)
        {
            if (null == value)
                return false;
            if (value.ToString() == _innertextfomate)
                return false;
            return true;
        }


        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata,
            ControllerContext context)
        {
            var rule = new ModelClientValidationRule
            {

                ErrorMessage = FormatErrorMessage(metadata.DisplayName),
                ValidationType = "requiredmessage" //以js对应  
            };
            _innertextfomate = String.Format(_innertext, metadata.DisplayName);
            rule.ValidationParameters["innertext"] = _innertextfomate;
            yield return rule;
        }
    }

}