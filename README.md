# TaxCalculator

    Tax calculator project implementing Rule Engine pattern.

## Structure

### 1. TaxCalculator.Server

    - Contains REST API Controller.
    - Using memory cache to check wheather we have calculated taxes for payer already.
    - With swagger

### 2. TaxCalculator.Services

    - Definitions of interfaces and classes dor all taxes and rules how to apply.

### 3. TaxCalculator.Tests

    - Unit tests for all rules
        a. Charity
        b. Income
        c. Social contribution
    - Unit tests for the RuleEngine

## Future Improvements

#### 1. Should create something like Tax norm with max and min border for every rule and remove `TaxationSettings.cs`.

#### 2. Register all of the rules in the `ConfigureService` of `Startup.cs`.

#### 3. Write summaries of classes and methods

#### 4. Use different validation
