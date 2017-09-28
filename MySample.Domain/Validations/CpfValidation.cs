namespace MySample.Domain.Validations
{
    public class CpfValidation
    {
        public static bool IsValid(string value)
        {
            value = value.Replace(".", "").Replace("-", "");

            if (value.Length != 11)
                return false;
            bool equal = true;
            for (int i = 1; i < 11 && equal; i++)
                if (value[i] != value[0])
                    equal = false;
            if (equal || value == "12345678909" || value == "90987654321")
                return false;
            int[] numbers = new int[11];
            for (int i = 0; i < 11; i++)
                numbers[i] = int.Parse(value[i].ToString());
            int sum = 0;
            for (int i = 0; i < 9; i++)
                sum += (10 - i) * numbers[i];
            int result = sum % 11;
            if (result == 1 || result == 0)
            {
                if (numbers[9] != 0)
                    return false;
            }
            else if (numbers[9] != 11 - result)
                return false;
            sum = 0;
            for (int i = 0; i < 10; i++)
                sum += (11 - i) * numbers[i];
            result = sum % 11;
            if (result == 1 || result == 0)
            {
                if (numbers[10] != 0)
                    return false;
            }
            else
                if (numbers[10] != 11 - result)
                return false;
            return true;
        }
    }
}
