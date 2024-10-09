package individualapplication.logiclayer.places;

import individualapplication.datalayer.placerepo.PlaceEntity;
import individualapplication.datalayer.placerepo.PlaceRepository;
import individualapplication.models.places.GetPlacesResponse;
import individualapplication.models.places.Place;
import lombok.AllArgsConstructor;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
@AllArgsConstructor
public class PlaceAdminImpl implements PlaceAdmin {
    private final PlaceRepository placeRepository;

    @Override
    public GetPlacesResponse getPlaces(){
        final GetPlacesResponse response = new GetPlacesResponse();
        List<Place> places = placeRepository.findAll()
                .stream().map(PlaceConverter:: convert)
                .toList();

        response.setPlaces(places);

        return response;

    }

    public PlaceEntity getById(Long id){
        return placeRepository.findById(id).orElseThrow();
    }

    public PlaceEntity getByName(String name){
        return placeRepository.findByName(name);
    }


}
