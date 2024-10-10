Feature: TomorrowsTemperature
Validation of tomorrows high temperature vs low temperature
        
    Scenario: high temperature is higher than low temperature
        Given I am on the BBC Weather page
        When I search for 'Bournemouth'
        Then tomorrow's high temperature is higher than tomorrow's low temperature