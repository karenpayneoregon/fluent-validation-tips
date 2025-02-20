# Use Fluent Validation to compare values in an array

From a Stackoverflow [post](https://stackoverflow.com/questions/79452317/use-fluent-validation-to-compare-values-in-an-array) were there is a reply marked as an answer but still in my opinion is flawed as the JSON to deserialize needs a converter.

In Program.cs

- `Original` method a datetime converter is added to the JSON serializer settings to deserialize the JSON string to a list of objects as dates
- `WithCorrectJson` method is the correct way to deserialize the JSON string to a list of objects as dates

In both methods are setup for failure as the second date is incorrect.

