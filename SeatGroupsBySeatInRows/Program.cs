var (rowsAndGroups, rowsSize, groupSize) = GetData();

int seatGroups = 0;

for (int i = 0; i < rowsAndGroups.Last(); i++)
{
    var group = groupSize[i];
    for (int j = 0; j < rowsSize.Count; j++)
    {
        var row = rowsSize[j];
        if (group <= row)
        {
            seatGroups++;
            //split if more than one group fit in a row without separating group members
            //rowsSize[j] -= group;
            //if (rowsSize[j] == 0)
            //{
            //    rowsSize.Remove(rowsSize[j]);
            //}

            break;
        }
    }
}

Console.WriteLine(seatGroups);
Console.ReadKey();


static (List<int> rowsAndGroups, List<int> rowsSize, List<int> groupsSize) GetData()
{
    Console.WriteLine("Input rows and groups amount separated by space");
    var rowsAndGroups = Console.ReadLine();

    Console.WriteLine("Input rows size amount separated by space");
    var rowsSize = Console.ReadLine();

    Console.WriteLine("Input groups size amount separated by space");
    var groupsSize = Console.ReadLine();

    var formatRowsAndGroups = SplitArrayItems(rowsAndGroups);
    var formatRowsSize = OrderByDesc(SplitArrayItems(rowsSize));
    var formatGroupsSize = OrderByDesc(SplitArrayItems(groupsSize));

    return (formatRowsAndGroups, formatRowsSize, formatGroupsSize);

}

static List<int> SplitArrayItems(string input)
{
    List<int> result = [];

    for (int i = 0; i < input.Length; i++)
    {
        var value = input[i].ToString();
        if (value != " ")
        {
            result.Add(Convert.ToInt32(value));
        }
    }

    return result;
}

static int GetMaxNumberInList(List<int> list)
{
    int max = 0;

    foreach (var item in list)
    {
        if (item > max)
        {
            max = item;
        }
    }

    return max;
}

static List<int> OrderByDesc(List<int> list)
{
    List<int> result = [];
    var listLength = list.Count;
    for (int i = 0; i < listLength; i++)
    {
        var maxNumber = GetMaxNumberInList(list);
        result.Add(maxNumber);
        list.Remove(maxNumber);
    }

    return result;
}