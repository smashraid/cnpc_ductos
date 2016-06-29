var GetTuberiaUrl = '/api/WSRegistroInspeccionVisual/GetTuberia';
var AddTuberiaUrl = '/api/WSRegistroInspeccionVisual/Post';
var UpdateTuberiaUrl = '/api/WSRegistroInspeccionVisual/Put';

app.factory('RegistroInspeccionVisualRepository', function ($http) {
    return {
        get: function (parameterlist) {
            return $http.get(GetTuberiaUrl,
            {
                params: {
                    oleoductoid: parameterlist.oleoductoid,
                    name: parameterlist.name,
                    page: parameterlist.page,
                    records: parameterlist.records
                }
            });
        },
        add: function (tuberia) {
            return $http.post(AddTuberiaUrl, tuberia);
        },
        delete: function (tuberia) {
            return $http.delete(oleoductoUrl + tuberia.id);
        },
        update: function (tuberia) {
            return $http.put(UpdateOleoductoUrl, tuberia);
        }
    };
});