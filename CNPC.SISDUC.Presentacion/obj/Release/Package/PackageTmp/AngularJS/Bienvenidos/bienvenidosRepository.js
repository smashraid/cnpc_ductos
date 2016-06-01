var ductoUrl = '/api/wsducto/';
app.factory('bienvenidosRepository', function ($http) {
    return {
        get: function () {
            return $http.get(ductoUrl);
        },
        add: function (ducto) {
            return $http.post(ductoUrl, ducto);
        },
        delete: function (ducto) {
            return $http.delete(ductoUrl + ducto.id);
        },
        update: function (ducto) {
            return $http.put(ductoUrl, ducto);
        }
    };
});