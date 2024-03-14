// Lili Zheng 20113384 LotteryApplication
// generate the random number of values that need users to enter
using System.Collections.Immutable;

int lowestValue = 5;
int highestValue = 10;
Random rnd = new Random();
int lowestRange = rnd.Next(0,9);
int highestRange = rnd.Next(10, 100);
int numberOfValues = rnd.Next(lowestValue, highestValue);
// create an empty array
int[] userInputArray = new int[numberOfValues];
int[] randomNumberArray = new int[numberOfValues];

// ask for user input, validate the input and put user input in an array
 Console.WriteLine($"Please enter {numberOfValues} values from {lowestRange} to {highestRange}, press enter after each one");
for(int i = 0; i < numberOfValues; i++)
{
    while (true)
    {
        Console.WriteLine($"Enter value {i + 1}: ");
        string userInput = Console.ReadLine();
        bool success = int.TryParse(userInput, out int userInputInt) & userInputInt >= lowestRange & userInputInt <=highestRange;
        if (success)
        {
            userInputArray[i] = userInputInt;
            break;
        }
        else
        {
            Console.WriteLine("Error! Please enter numbers within the range.");
        }
    }
    
}

Console.WriteLine("\nHere are the results:");

    // generate random numbers and enter these numbers into random number array
    for (int i = 0; i < numberOfValues; i++)
    {
        int randomNumber = rnd.Next(lowestRange, highestRange);
        randomNumberArray[i] = randomNumber;
    }

    // Conduct the binary search compare the values in the userInputArray against randomNumberArray
    // Provide the results for users
int BinarySearch(int[] randomNumberArray, int value, int low, int high)
{
    if(high >= low)
    {
        int mid = low + ((high - low) / 2);
        if (randomNumberArray[mid] == value) return mid;
        if (randomNumberArray[mid] > value) return BinarySearch(randomNumberArray, value, low, mid -1);
        return BinarySearch(randomNumberArray, value, mid+1, high);
    }
    return -1;
}
void CompareArrays(int[] randomNumberArray, int[] userInputArray, int low, int high)
{
    Array.Sort(randomNumberArray);
    for (int i = 0;i < numberOfValues;i++)
    {
        int result = BinarySearch(randomNumberArray, userInputArray[i], low, high);
        if (result == -1)
        {
            Console.WriteLine($"{userInputArray[i]} not found!");
        }
        else
            Console.WriteLine($"{userInputArray[i]} matched!");
    }
}

CompareArrays(randomNumberArray, userInputArray, 0, numberOfValues-1);