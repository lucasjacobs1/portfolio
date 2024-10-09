package individualapplication.logiclayer.places;

import individualapplication.datalayer.placerepo.PlaceEntity;
import individualapplication.models.places.GetPlacesResponse;

public interface PlaceAdmin{
    GetPlacesResponse getPlaces();
    PlaceEntity getById(Long id);
    PlaceEntity getByName(String name);
}
