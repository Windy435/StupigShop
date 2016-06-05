(function (app) {
    app.filter('statusFilter', function(){
        return function(input){
            if(input == true)
                return 'Enable';
            else
                return 'Disable';
        }
    });
})(angular.module('stupigshop.common'));