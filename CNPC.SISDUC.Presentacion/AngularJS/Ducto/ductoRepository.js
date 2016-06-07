var ductoUrl = '/api/wsducto/';
app.factory('ductoRepository', function ($http) {
    return {
        get: function (parameterlist) {
            return $http.get(ductoUrl,
            {
                params: {
                    name: parameterlist.name,
                    page: parameterlist.page,
                    records: parameterlist.records
                }
            });
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