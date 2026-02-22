namespace GeniyIdiot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] questions = GetQuestions();
            var questionsCount = questions.Length;
            int[] answers = GetAnswers(questionsCount);

            Console.WriteLine("Введите Ваше имя:");
            var userName = Console.ReadLine();

            while (true)
            {
                var rightAnswerCount = 0;
                var indexesList = MixIndexes(questionsCount);

                for (int i = 0; i < questionsCount; i++)
                {
                    var index = indexesList[i];
                    ShowQuestion(questions[index], i);

                    var userAnswer = GetUserAnswer();

                    rightAnswerCount = CalculateAnswer(userAnswer, answers[index], rightAnswerCount);
                }

                var diagnose = GetDiagnose(questionsCount, rightAnswerCount);

                Console.WriteLine($"{userName}, Ваш диагноз: {diagnose}");

                var userConfirm = IsContinue();

                if (userConfirm)
                {
                    Console.Clear();
                }
                else
                {
                    break;
                }
            }
        }

        public static string[] GetQuestions()
        {
            string[] questions =  new string[5];

            questions[0] = "Сколько будет два плюс два умноженное на два?";
            questions[1] = "Бревно нужно распилить на 10 частей, сколько нужно сделать распилов?";
            questions[2] = "На двух руках 10 пальцев, сколько пальцев на пяти руках?";
            questions[3] = "Укол делают каждые полчаса, сколько нужно минут для 3х уколов?";
            questions[4] = "Пять свечей горело, 2 потухли, сколько свечей осталось?";

            return questions;
        }

        public static int[] GetAnswers(int questionsCount)
        {
            int[] answers = new int[questionsCount];

            answers[0] = 6;
            answers[1] = 9;
            answers[2] = 25;
            answers[3] = 60;
            answers[4] = 2;

            return answers;
        }

        public static int GetUserAnswer()
        {
            int userAnswer = -1;
            Console.WriteLine("Введите число:");

            while (userAnswer < 0 || userAnswer > 999) 
            {
                if (int.TryParse(Console.ReadLine(), out userAnswer))
                {
                    if (userAnswer > 999)
                    {
                        Console.WriteLine("Ответ должен быть числом от 0 до 1000! Введите ответ:");
                        userAnswer = -1;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Ответ должен быть числом! Введите ответ:");
                    userAnswer = -1;
                }
            }
            return userAnswer;
        }

        public static string GetDiagnose(int questionsCount, int rightAnswerCount)
        {
            int diagnose = (int)(((double)rightAnswerCount / questionsCount) * 100);

            switch (diagnose)
            {
                case <= 20: return "Кретин";
                case <= 40: return "Дурак";
                case <= 60: return "Нормальный";
                case <= 80: return "Таллант";
                case <= 100: return "Гений";

                default: return "Идиот";
            }
        }

        public static void ShowQuestion(string question, int numberQuestion)
        {
            Console.WriteLine("Вопрос номер " + (numberQuestion + 1) + ":");
            Console.WriteLine(question);
        }

        public static int CalculateAnswer(int userAnswer, int rightAnswer, int rightAnswerCount)
        {
            rightAnswerCount += (userAnswer == rightAnswer) ? 1 : 0;
            return rightAnswerCount;
        }

        public static List<int> MixIndexes(int questionsCount)
        {
            Random random = new Random();
            var indexesList = new List<int>();

            while (indexesList.Count < questionsCount)
            {
                int randomIndex = random.Next(0, questionsCount);

                if (!indexesList.Contains(randomIndex))
                {
                    indexesList.Add(randomIndex);
                }
            }

            return indexesList;
        }

        public static bool IsContinue()
        {
            Console.WriteLine("Хотите снова пройти тест?");

            while (true)
            {
                Console.WriteLine($"\"Да или Нет?\"");
                var userConfirm = Console.ReadLine().ToLower().Trim();

                if (userConfirm == "да")
                {
                    return true;
                }
                else if (userConfirm == "нет")
                {
                    return false;
                }
                else { continue; }
            }
        }
    }
}
