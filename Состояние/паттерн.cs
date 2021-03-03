namespace Solution {
    class Program {
        public StateClass state = new StateStop();
        public var context = new LexContext(state);

        public bool Check (IEnumerable<Lexeme> lexemes)
        {
            foreach(var lexeme in lexemes) {

                var check = context.CheckLexeme(lexeme);
                if (!check)
                    break;
            }
        }
    }

    public enum Lexeme {
        Red,
        Yellow,
        Green,
        Section
    }

    public enum State {
        Stop,
        Prepare,
        Straight,
        TurnRight,
        Fine
    }

    public abstract class StateClass {
        bool HandleRed (LexContext context) {
            return false;
        }
        bool HandleYellow (LexContext context) {
            return false;
        }
        bool HandleGreen (LexContext context) {
            return false;
        }
        bool HandleSection (LexContext context) {
            return false;
        }
    }

    public class StateStop : State {

        public override bool HandleYellow (LexContext context) {
            context.state = new StatePrepare ();
            Console.WriteLine ($"From {State.Stop} to {State}");
            return true;
        }
        public override bool HandleGreen (LexContext context) {
            context.state = new StateFine().Count();
            return true;
        }
        public override bool HandleSection (LexContext context) {
            context.state = new StateTurnRight ();
            return true;
        }
    }

    public class StatePrepare : State {
        public override bool HandleRed (LexContext context) {
            context.state = new StateStop ();
            return true;
        }

        public override bool HandleGreen (LexContext context) {
            context.state = new StateStraight ();
            return true;
        }
    }

    public class StateStraight : State {
        public override bool HandleYellow (LexContext context) {
            context.state = new StatePrepare ();
        }
    }

    public class StateTurnRight : State {
        public override bool HandleRed (LexContext context) {
            context.state = new StateStop ();
        }
    }

    public class StateFine : State {
        public void Count (LexContext context) {
            context.FineCount++;
        }
    }

    class LexContext {
        StateClass currentstate { get; set; }
        public int FineCount = 0;
        public LexContext (StateClass state) {
            currentstate = state;
        }
        
        public bool CheckLexeme(Lexeme lexeme) {
            if (lexeme == Lexeme.Red)
                return currentstate.HandleRed(this);
            else if (lexeme == Lexeme.Yellow)
                return currentstate.HandleYellow(this);
            else if (lexeme == Lexeme.Green)
                return currentstate.HandleGreen(this);
            else 
                return currentstate.HandleSection(this);
        }
    }
}