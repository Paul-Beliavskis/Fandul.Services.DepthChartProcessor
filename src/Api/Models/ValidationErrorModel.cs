﻿namespace Fandul.Services.DepthChartProcessor.Models
{
    public class ValidationErrorModel
    {
        /// <summary>
        /// The name of the property.
        /// </summary>
        public string PropertyName { get; set; }

        /// <summary>
        /// The error message
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// The property value that caused the failure.
        /// </summary>
        public object AttemptedValue { get; set; }
    }
}
