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

        public DialogBuilder AddResponse(string response, string nextSegment, Action<DialogBuilder>? buildAction = null, Action<GameState>? onChosen = null)
        {
            DialogBuilder continuation = new DialogBuilder(nextSegment);
            buildAction?.Invoke(continuation);
            Responses.Add(new DialogResponse(response, continuation.Build(), onChosen));
            return this;
        }

        public DialogBuilder AddResponse(string response, Action<GameState>? onChosen = null)
        {
            Responses.Add(new DialogResponse(response, onChosen: onChosen));
            return this;
        }

        public DialogSegment Build()
        {
            return new DialogSegment(Text, Responses);
        }
    }
}
