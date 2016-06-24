'use strict';
var app = angular.module('demoapp');
app.controller('SearchController', function($scope) {
    $scope.Message = "This is Search page...........";
     
        $scope.message = "Hello from testController";
        // Display an info toast with no title
        toastr.info('Loading Search parameters...');
        $scope.availableSearchParams = [
      { key: "charter", name: "Charter", placeholder: "Charter..." },
      { key: "institution", name: "Institution", placeholder: "Insitution...", restrictToSuggestedValues: true, suggestedValues: ['Citibank', 'JP Morgan', 'Bank of America'] },
      { key: "city", name: "City", placeholder: "City...", restrictToSuggestedValues: false, suggestedValues: ['New York', 'Dallas', 'Chicago', 'London', 'Paris'] },
      { key: "district", name: "District", placeholder: "District...", restrictToSuggestedValues: true, suggestedValues: ['Central', 'Northeastern', 'Southern', 'Western', 'Midsize and Credit Card', 'Large Bank', 'Headquarters', 'Technology Service Providers', 'International Banking'] },
      { key: "job", name: "Job No.", placeholder: "Job No..." }
        ];
    
});
