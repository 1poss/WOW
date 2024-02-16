namespace WOW {

    public enum InputEnum {

        None,

        Skill1 = 100,
        Skill2 = 101,
        Skill3 = 102,
        Skill4 = 103,
        Skill5 = 104,

        ChooseTeamer1 = 200,
        ChooseTeamer2 = 201,
        ChooseTeamer3 = 202,
        ChooseTeamer4 = 203,

        CancelChose,
    }

    public static class InputEnumExtension {

        public static int ToChosenTeamerIndex(this InputEnum input) {
            switch (input) {
                case InputEnum.ChooseTeamer1:
                    return 0;
                case InputEnum.ChooseTeamer2:
                    return 1;
                case InputEnum.ChooseTeamer3:
                    return 2;
                case InputEnum.ChooseTeamer4:
                    return 3;
                default:
                    return -1;
            }
        }
    }
}