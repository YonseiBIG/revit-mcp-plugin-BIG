using Autodesk.Revit.UI;
using Newtonsoft.Json.Linq;
using revit_mcp_sdk.API.Base;
using System;

namespace SampleCommandSet.Commands.Access
{
    /// <summary>
    /// Command to retrieve the currently selected elements.
    /// </summary>
    public class GetSelectedElementsCommand : ExternalEventCommandBase
    {
        private GetSelectedElementsEventHandler _handler => (GetSelectedElementsEventHandler)Handler;

        public override string CommandName => "get_selected_elements";

        public GetSelectedElementsCommand(UIApplication uiApp)
            : base(new GetSelectedElementsEventHandler(), uiApp)
        {
        }

        public override object Execute(JObject parameters, string requestId)
        {
            try
            {
                // Parse parameters
                int? limit = parameters?["limit"]?.Value<int>();

                // Set the count limit
                _handler.Limit = limit;

                // Raise the external event and wait for completion
                if (RaiseAndWaitForCompletion(15000))
                {
                    return _handler.ResultElements;
                }
                else
                {
                    throw new TimeoutException("Timed out while retrieving selected elements");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve selected elements: {ex.Message}");
            }
        }
    }
}
