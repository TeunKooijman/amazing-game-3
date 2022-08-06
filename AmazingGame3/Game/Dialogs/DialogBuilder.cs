namespace AmazingGame3.Dialogs
{
    public class DialogBuilder
    {
        public string Text { get; }
        public List<DialogResponse> Responses { get; }

        public DialogBuilder(string text)
        {
            Responses = new List<DialogResponse>();
            Text = text;
        }

        public DialogBuilder AddResponse(string response, string nextSegment, Action<DialogBuilder>? buildAction = null, Func<GameState, Task>? onChosenAsync = null)
        {
            DialogBuilder continuation = new DialogBuilder(nextSegment);
            buildAction?.Invoke(continuation);
            Responses.Add(new DialogResponse(response, continuation.Build(), onChosenAsync));
            return this;
        }

        public DialogBuilder AddResponse(string response, Func<GameState, Task>? onChosenAsync = null)
        {
            Responses.Add(new DialogResponse(response, onChosenAsync: onChosenAsync));
            return this;
        }

        public DialogSegment Build()
        {
            return new DialogSegment(Text, Responses);
        }
    }
}
