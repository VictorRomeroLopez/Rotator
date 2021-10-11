    namespace Core
    {
        public static class EventManager
        {
            public delegate void EmptyEvent();
            public delegate void CellDirectionEvent(CellDirection direction);

            public static CellDirectionEvent OnRotationEnded;

            public static EmptyEvent OnRotateLeft;
            public static EmptyEvent OnRotateRight;
            public static EmptyEvent OnPlayerMovementEnded { get; set; }
            public static EmptyEvent OnLevelCompleted { get; set; }
            public static EmptyEvent OnLevelFailed { get; set; }
        }
    }