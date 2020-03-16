using System;
using UnityEngine;

internal static class RandomizeFindableItems
{
    static RandomizeFindableItems()
    {
        LevelApi.OnLevelStart += OnRandomizeFindableItems;
    }

	private static void OnRandomizeFindableItems(int level)
	{
		// In an array you need to get index 0 for level 1.
		level--;

		GameObject[] itemSpawners = GameObject.FindGameObjectsWithTag("Item Spawner");
		GameObject[] itemPrefabs = Properties.levelData[level].items;
		GameObject[] itemInstances;
		int itemSpawnNumber = Properties.levelData[level].itemSpawnNumber;

		// If there are more items that need to be spawned than item spawners.
		if (itemSpawners.Length < Properties.levelData[level].itemSpawnNumber)
		{
			Debug.LogWarning(
				"There are " + itemSpawners.Length + " item spawners, " +
				"but the number of items that need to be spawned is set to " + Properties.levelData[level].itemSpawnNumber + ". " +
				"Only " + itemSpawners.Length + " items will spawn in. " +
				"Please reduce the number of items that need to be spawned or add more item spawners."
			);
			itemSpawnNumber = itemSpawners.Length;
		}

		// Shuffle all items.
		itemPrefabs = Shuffle(itemPrefabs);

		// Resize items array to itemSpawnNumber.
		Array.Resize(ref itemPrefabs, itemSpawnNumber);

		// Instantiate all items.
		itemInstances = new GameObject[itemSpawnNumber];

		for (int i = 0; i < itemSpawnNumber; i++)
			itemInstances[i] = UnityEngine.Object.Instantiate(itemPrefabs[i], itemSpawners[i].transform.position, Quaternion.identity, itemSpawners[i].transform);

		// Add the instances of the items to the Properties class.
		Properties.currentFindableItems = itemInstances;
	}

	private static T[] Shuffle<T>(T[] array)
	{
		T tempValue;

		for (int i = 0; i < array.Length; i++)
		{
			int rnd = UnityEngine.Random.Range(0, array.Length);
			tempValue = array[rnd];
			array[rnd] = array[i];
			array[i] = tempValue;
		}

		return array;
	}
}
