using CustomForms.Data;
using Microsoft.AspNetCore.Components;

namespace CustomForms.ServerApp.Pages
{
    public class InputFieldBase : ComponentBase
    {
        [Parameter]
        public FormInputField ViewModel { get; set; }

    }
}
