namespace AmazingGame3.Dialogs
{
    public class DialogResponse
    {
        public string Response { get; }
        public DialogSegment? NextSegment { get; }
        public Func<GameState, Task> OnChosenAsync { get; }

        public DialogResponse(string response, DialogSegment? nextSegment = null, Func<GameState, Task>? onChosenAsync = null)
        {
            Response = response;
            NextSegment = nextSegment;
            OnChosenAsync = onChosenAsync != null
                ? onChosenAsync
                : (state) => 
                {
                    return Task.CompletedTask;
                };
        }
    }
}
