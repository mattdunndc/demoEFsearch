'use strict';
app.controller('SearchController', function($scope, notifyService) {

    $scope.message = "search controller";
    // todo: REST call
    notifyService.info('Loading Search parameters......');
    
    $scope.availableSearchParams = [
      { key: "charter", name: "Charter", placeholder: "Charter..." },
      { key: "institution", name: "Institution", placeholder: "Insitution...", suggestedValues: ['Citibank', 'JP Morgan', 'Bank of America'] },
      { key: "city", name: "City", placeholder: "City...", restrictToSuggestedValues: false, suggestedValues: ['New York', 'Dallas', 'Chicago', 'London', 'Paris'] },
      { key: "district", name: "District", placeholder: "District...", restrictToSuggestedValues: true, suggestedValues: ['Central', 'Northeastern', 'Southern', 'Western', 'Midsize and Credit Card', 'Large Bank', 'Headquarters', 'Technology Service Providers', 'International Banking'] },
      { key: "job", name: "Job No.", placeholder: "Job No..." }
    ];
  
});
