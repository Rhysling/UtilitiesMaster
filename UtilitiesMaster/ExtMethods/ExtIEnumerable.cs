namespace UtilitiesMaster.ExtMethods;

public static class ExtIEnumerable
{
	public static bool IsEmpty<T>(this IEnumerable<T> source)
	{
		if (source is null) return true;
		return !source.Any();
	}

}
