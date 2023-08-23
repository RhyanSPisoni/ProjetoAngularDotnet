var obj = {
    codigo: 0,
    nome: "",
    cpf: "",
    endereco: "",
    telefone: ""
}

angular.module("UserPg", [])
angular.module("UserPg").controller("UserCtrl", function ($scope, $http) {
    $scope.texto = '';
    $scope.dadosApi = []
    $scope.BuscaUsuarios = function () {
        $http.get(`http://localhost:5134/User/SearchUsers`)
            .then(function (data) {
                $scope.dadosApi = data.data
            })
    }

    $scope.NovoUsuario = function (nome, cpf, endereco, telefone) {
        obj.nome = nome
        obj.cpf = cpf.toString()
        obj.endereco = endereco
        obj.telefone = telefone.toString()

        var _codigo = document.getElementById("id_codigo").value;

        if (_codigo.length == 0) {
            var promise = $http.post("http://localhost:5134/User", obj);
            promise.then(function (event) {
                $http.get(`http://localhost:5134/User/SearchUsers`)
                    .then(function (data) {
                        $scope.dadosApi = data.data
                        LimpaCamposUser();
                    })
            })
        }
        else {

            obj.codigo = _codigo
            obj.nome = document.getElementById("id_nome").value
            obj.cpf = document.getElementById("id_cpf").value.toString()
            obj.endereco = document.getElementById("id_endereco").value
            obj.telefone = document.getElementById("id_telefone").value.toString()

            var promise = $http.patch("http://localhost:5134/User", obj);
            promise.then(function (event) {
                $http.get(`http://localhost:5134/User/SearchUsers`)
                    .then(function (data) {
                        $scope.dadosApi = data.data

                        LimpaCamposUser();
                    })
            })

        }
    }

    $scope.LimparCamposUserNg = function () {
        document.getElementById("id_codigo").value = ""
        document.getElementById("id_nome").value = ""
        document.getElementById("id_cpf").value = ""
        document.getElementById("id_endereco").value = ""
        document.getElementById("id_telefone").value = ""
    }

    function LimpaCamposUser() {
        console.log("Aqui")
        obj.codigo = 0
        obj.nome = ""
        obj.cpf = ""
        obj.endereco = ""
        obj.telefone = ""

        document.getElementById("id_codigo").value = ""
        document.getElementById("id_nome").value = ""
        document.getElementById("id_cpf").value = ""
        document.getElementById("id_endereco").value = ""
        document.getElementById("id_telefone").value = ""
    }

    $scope.EditarUsuario = function (dado) {
        obj.codigo = dado.codigo
        obj.nome = dado.nome
        obj.cpf = dado.cpf.toString()
        obj.endereco = dado.endereco
        obj.telefone = dado.telefone.toString()

        document.getElementById("id_codigo").value = dado.codigo
        document.getElementById("id_nome").value = dado.nome
        document.getElementById("id_cpf").value = dado.cpf.toString()
        document.getElementById("id_endereco").value = dado.endereco
        document.getElementById("id_telefone").value = dado.telefone.toString()
        console.log(dado)
    }

    $scope.AtualizarUsuario = function (codigo, nome, cpf, endereco, telefone) {
        let obj = {
            codigo: codigo,
            nome: nome,
            cpf: cpf.toString(),
            endereco: endereco,
            telefone: telefone.toString()
        }

        var promise = $http.patch("http://localhost:5134/User", obj);
        promise.then(function (event) {

            $http.get(`http://localhost:5134/User/SearchUsers`)
                .then(function (data) {
                    $scope.dadosApi = data.data
                })
        })
    }

    $scope.DeletarUsuario = function (codigo) {

        $http.delete(`http://localhost:5134/User?id=${codigo}`)
            .then(function (data) {

                $http.get(`http://localhost:5134/User/SearchUsers`)
                    .then(function (data) {
                        $scope.dadosApi = data.data
                    })
            })
    }
})