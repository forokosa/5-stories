using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace calories_trecker;

public class MainViewModel : INotifyPropertyChanged
{
    public ObservableCollection<FoodItem> Foods { get; set; } = new();

    private string _foodName = "";
    public string FoodName
    {
        get => _foodName;
        set
        {
            _foodName = value;
            OnPropertyChanged(nameof(FoodName));
        }
    }

    private double _weight;
    public double Weight
    {
        get => _weight;
        set
        {
            _weight = value;
            OnPropertyChanged(nameof(Weight));
        }
    }

    private int _calories;
    public int Calories
    {
        get => _calories;
        set
        {
            _calories = value;
            OnPropertyChanged(nameof(Calories));
        }
    }

    private string _mealTime = "";
    public string MealTime
    {
        get => _mealTime;
        set
        {
            _mealTime = value;
            OnPropertyChanged(nameof(MealTime));
        }
    }

    public int TotalCalories => Foods.Sum(f => f.Calories);

    public void AddFood()
    {
        if (string.IsNullOrWhiteSpace(FoodName))
            return;

        Foods.Add(new FoodItem
        {
            Name = FoodName,
            Weight = Weight,
            Calories = Calories,
            MealTime = MealTime
        });

        // обновляем UI
        OnPropertyChanged(nameof(TotalCalories));

        // очистка полей
        FoodName = "";
        Weight = 0;
        Calories = 0;
        MealTime = "";
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged(string name)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}