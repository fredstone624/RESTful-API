using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;

namespace SimpleGallery.API.Extensions
{
    public static class ModelStateExtensions
    {
        public static IEnumerable<string> GetErrorMessages(this ModelStateDictionary dictionary) =>
            dictionary.SelectMany(m => m.Value.Errors).Select(m => m.ErrorMessage);
    }
}