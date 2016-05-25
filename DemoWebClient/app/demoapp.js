﻿var app = angular.module('demoapp', ['ngRoute', 'ngResource','angularUtils.directives.dirPagination']);
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
      .when('/Home/Contact', { // For Contact page  
          templateUrl: '/app/views/contact.html',
          controller: 'ContactController'
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
      .when('/Home/NRPT/:userid?', { // add question mark for optional parameter   
          templateUrl: '/Scripts/app/views/NRPT.html',
          controller: 'NRPTController'
      })
      .otherwise({ redirectTo: '/' })
  }]);