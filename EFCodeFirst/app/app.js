var mod = angular.module('testapp', ['ngRoute','ui.bootstrap', 'angular-advanced-searchbox', 'ngResource', 'angularUtils.directives.dirPagination']);
mod.config([
  '$locationProvider', '$routeProvider',
  function ($locationProvider, $routeProvider) {
      $locationProvider.html5Mode({
          enabled: true,
          requireBase: false
      }).hashPrefix('!'); //default hashPrefix is !
      $routeProvider
      .when('/', { // For Home Page  
          templateUrl: '/app/views/home.html',
          controller: 'homeController'
      })
      .when('/Home/Contact', { // For Contact page  
          templateUrl: '/app/views/contact.html',
          controller: 'userCtrl'
      })
      .when('/Home/Search', { // For Search page  
          templateUrl: '/app/views/search.html',
          controller: 'testCtrl'
      })
      .when('/Home/NRPT/:userid?', { // add question mark for optional parameter   
          templateUrl: '/app/views/NRPT.html',
          controller: 'NRPTController'
      })
      .otherwise({  // This is when any route not matched => error  
          controller: 'ErrorController'
      })
  }]);