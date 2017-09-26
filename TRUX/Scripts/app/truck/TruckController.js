(function () {

    'use strict';
    angular.module('truxApp').controller('truckController', truckController);

    truckController.$inject = ['$scope', 'truckService'];

    function truckController($scope, truckService) {
        var vm = this;
        vm.$scope = $scope;
        vm.truckService = truckService;
        vm.displayBodyContent = false;
        vm.selectAll = _selectAll;
        vm.createTruck = _createTruck;
        vm.save = _save;
        vm.cancel = _cancel;
        vm.editUser = _editUser;
        vm.deleteUser = _deleteUser;
        vm.renderTrux = _renderTrux;

        vm.items = [];
        vm.selectedItem = null;
        vm.itemToDelete = null;
        vm.message = "Welcome to the Trux page!!!";
        vm.heading = "Create a new Truck";

        render();
        function render() {
            console.log("TruX index page is ready");
            vm.selectAll();
        };

        function _selectAll() {
            console.log("Executing TruX Service SelectAll()...");
            vm.truckService.selectAll(onSelectAllSuccess, onError);
            vm.displayBodyContent = true;
            console.log("Executed TruX Service SelectAll()");
        };

        function _createTruck() {
            vm.selectedItem = {};
            console.log("New Truck has been created!");
        };

        function _renderTrux() {
            $("tbody tr").remove();
            for (var i = 0; i < vm.items.length; i++) {
                var template = $($('#template').html());
                template.find(".id").text(vm.items[i].id);
                template.find(".firstName").text(vm.items[i].firstName);
                template.find(".lastName").text(vm.items[i].lastName);
                template.find(".middleInitial").text(vm.items[i].middleInitial);
                template.appendTo(".peopleList");
            }
            $("tbody").on("click", ".edit", vm.editUser);
            $("tbody").on("click", ".delete", vm.deleteUser);
        };

        function _save() {
            console.log("Executing TruX Service Save()...");
            if (vm.selectedItem.id) {
                vm.truckService.update(vm.selectedItem, onUpdateSuccess, onError);
            } else {
                vm.truckService.save(vm.selectedItem, onSaveSuccess, onError);
            }
            console.log("Executed TruX Service Save()");
        };

        function _cancel() {
            vm.selectedItem = null;
        };

        function _editUser() {
            var targetId = $(this).closest('tr').find('.id').text();
            var selectedId = parseInt(targetId);
            for (var i = 0; i < vm.items.length; i++) {
                if (vm.items[i].id == selectedId) {
                    vm.$scope.$apply(function () {
                        vm.selectedItem = vm.items[i];
                    });
                    break;
                }
            }
        };

        function _deleteUser() {
            var targetId = $(this).closest('tr').find('.id').text();
            vm.itemToDelete = parseInt(targetId);
            for (var i = 0; i < vm.items.length; i++) {
                if (vm.items[i].id == vm.itemToDelete) {
                    vm.truckService.delete(vm.itemToDelete, onDeleteSuccess, onError);
                    break;
                }
            }
        };

        function onSelectAllSuccess(data) {
            console.log("People Service SelectAll() was successful!");
            vm.items = data.items;
            vm.renderTrux();
        };

        function onSaveSuccess(data) {
            console.log("People Service Save() was successful!");
            vm.selectedItem.id = data.item;
            vm.items.push(vm.selectedItem);
            vm.$scope.$apply(function () {
                vm.selectedItem = null;
            });
            vm.renderTrux();
            //render();
        };

        function onUpdateSuccess(data) {
            console.log("People Service Update() was successful!");
            var trArray = $('.peopleList tr');
            for (var index = 0; index < trArray.length; index++) {
                var id = $(trArray[index]).find('.id').text();
                if (vm.selectedItem.id == parseInt($(trArray[index]).find('.id').text())) {
                    $(trArray[index]).find('.firstName').text(vm.selectedItem.firstName);
                    $(trArray[index]).find('.lastName').text(vm.selectedItem.lastName);
                    $(trArray[index]).find('.middleInitial').text(vm.selectedItem.middleInitial);
                    break;
                }
            }
            vm.$scope.$apply(function () {
                vm.selectedItem = null;
            });
        };

        function onDeleteSuccess(data) {
            console.log("People Service Delete() was successful!");
            var tdArray = $('.peopleList tr td:first-child');
            for (var index = 0; index < tdArray.length; index++) {
                if (tdArray[index].textContent == vm.itemToDelete) {
                    vm.$scope.$apply(function () {
                        vm.items.splice(index, 1);
                    });
                    break;
                }
            }
            vm.renderTrux();
        };

        function onError(xhr, ajaxOptions, thrownError) {
            console.log(xhr.responseText);
        };
    };

})();