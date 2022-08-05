namespace AmazingGame3.Dialogs
{
    public class DialogResponse
    {
        public string Response { get; }
        public DialogSegment? NextSegment { get; }
        public Action<GameState> OnChosen { get; }

        public DialogResponse(string response, DialogSegment? nextSegment = null, Action<GameState>? onChosen = null)
        {
            Response = response;
            NextSegment = nextSegment;
            OnChosen = onChosen != null
                ? onChosen
                : (state) => { };
        }
    }
}
