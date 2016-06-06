var app = angular.module('demoapp', ['ngRoute', 'ngResource','angularUtils.directives.dirPagination']);
app.config([
  '$locationProvider', '$routeProvider',
  function ($locationProvider, $routeProvider) {
      $locationProvider.html5Mode({
          enabled: true,
          requireBase: false
      }).hashPrefix('!');
      $routeProvider
      .when('/', { // For Home Page  
          templateUrl: '/app/views/home.html',
          controller: 'HomeController'
      })
      .when('/Home/Department', { // MVC For Contact page  
          templateUrl: '/app/views/dept.html',
          controller: 'DepartmentController'
      })
      .when('/Home/Institution', { // For instit page  
          templateUrl: '/app/views/institution.html',
          controller: 'InstitutionController'
      })
      .when('/Home/About', { // For About page  
          templateUrl: '/app/views/about.html',
          controller: 'AboutController'
      })
      .when('/Home/Search', { // For search page  
          templateUrl: '/app/views/search.html',
          controller: 'SearchController'
      })
      .when('/Home/Institution/edit/:id?', { // add question mark for optional parameter   
          templateUrl: '/app/views/instEdit.html',
          controller: 'InstitutionAddEditController',
          controllerAs: 'vm'
      })
      .otherwise({ redirectTo: '/' })
  }]);