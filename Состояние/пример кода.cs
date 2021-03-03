namespace ConsoleApp1 {
    class Program {
        public State State { get; private set; }

        public int FineCount = 0;

        public bool Check (IEnumerable<Lexeme> lexemes) {
            foreach (var lexeme in lexemes) {
                if (State == State.Stop)
                    if (lexeme == Lexeme.Yellow) {
                        State = State.Prepare;
                        Console.WriteLine ($"From {State.Stop} to {State}");
                    }
                else if (lexeme == Lexeme.Green) State = State.Fine;
                else if (lexeme == Lexeme.Section) State = State.TurnRight;
                else return false;
                else if (State == State.Prepare)
                    if (lexeme == Lexeme.Red) State = State.Stop;
                    else if (lexeme == Lexeme.Green) State = State.Straight;
                else return false;
                else if (State == State.Straight)
                    if (lexeme == Lexeme.Yellow) State = State.Prepare;
                    else return false;
                else if (State == State.TurnRight)
                    if (lexeme == Lexeme.Red) State = State.Stop;
                    else return false;
                else if (State == State.Fine)
                    FineCount++;
                else return false;
            }
            Console.Write ($"FineCount: {FineCount}");
            return State == State.Fine;
        }
    }

    public enum Lexeme {
        Red,
        Yellow,
        Green,
        Section,
    }

    public enum State {
        Stop,
        Prepare,
        Straight,
        TurnRight,
    }