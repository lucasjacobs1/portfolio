package individualapplication.logiclayer.places;

import individualapplication.datalayer.placerepo.PlaceEntity;
import individualapplication.models.places.Place;

public final class PlaceConverter {
    private PlaceConverter(){

    }

    public static Place convert(PlaceEntity placeEntity){
        return Place.builder()
                .id(placeEntity.getId())
                .name(placeEntity.getName())
                .build();
    }


}
