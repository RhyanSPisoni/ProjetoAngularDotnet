angular.module("LoginPg", []);
angular.module("LoginPg").controller("LoginCtrl", function ($scope, $http) {

    $scope.VerificaLogin = function (user, pass) {
        // user = "SISTEMA"
        // pass = "candidato123"
        $http.get(`http://localhost:5134/Login?user=${user}&pass=${pass}`)
            .then(function (data) {
                if (data.data) {
                    window.location.href = "./layout.html";
                }
            })
    }
})