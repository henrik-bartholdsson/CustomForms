using CustomForms.Data;
using CustomForms.Statics;
using Microsoft.AspNetCore.Components;

namespace CustomForms.ServerApp.Pages
{
    public class IndexBase : ComponentBase
    {
        public Form TheForm { get; set; } = new Form();

        protected override async Task OnInitializedAsync()
        {
            TheForm.Fields = new List<CustomForms.Data.FormInputField> {
                new CustomForms.Data.FormInputField { Data = "Some text", FieldType = FieldTypes.text },
                new CustomForms.Data.FormInputField { Data = "", FieldType = FieldTypes.text, Placeholder = "Some text" },
                new CustomForms.Data.FormInputField { Data = "", FieldType = FieldTypes.radio },
                new CustomForms.Data.FormInputField { Data = "", FieldType = FieldTypes.number }
                };
        }
    }
}
