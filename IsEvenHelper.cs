namespace Miz.IsEven.ML.Net.Core;

using System;
using System.Globalization;

public static class IsEvenHelper
{
    public static bool IsEven<T>(this T number) where T : INumber<T>, IConvertible
    {
        var sampleData = new IsEvenMLClassifierModel.ModelInput() {
            Number = number.ToSingle(CultureInfo.CurrentCulture),
        };

        return IsEvenMLClassifierModel.Predict(sampleData).Prediction == "Even";
    }

    public static bool IsEven<T>(this T number, out float confidence) where T : INumber<T>, IConvertible {
        var sampleData = new IsEvenMLClassifierModel.ModelInput() {
            Number = number.ToSingle(CultureInfo.CurrentCulture),
        };

        var prediction = IsEvenMLClassifierModel.Predict(sampleData);
        bool isEven = prediction.Prediction == "Even";

        // even confidence score is in index 0, odd index 1.
        confidence = prediction.Score[isEven ? 0 : 1];

        return isEven;
    }
}