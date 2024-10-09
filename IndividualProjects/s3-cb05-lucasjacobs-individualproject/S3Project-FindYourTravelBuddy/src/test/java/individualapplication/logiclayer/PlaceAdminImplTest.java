package individualapplication.logiclayer;

import individualapplication.datalayer.placerepo.PlaceEntity;
import individualapplication.datalayer.placerepo.PlaceRepository;
import individualapplication.logiclayer.places.PlaceAdminImpl;
import individualapplication.models.places.GetPlacesResponse;
import individualapplication.models.places.Place;
import individualapplication.models.user.preferences.CreatePreferenceResponse;
import lombok.AllArgsConstructor;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.extension.ExtendWith;
import org.mockito.InjectMocks;
import org.mockito.Mock;
import org.mockito.Mockito;
import org.mockito.junit.jupiter.MockitoExtension;
import org.springframework.stereotype.Service;

import java.util.List;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.mockito.Mockito.verify;

@ExtendWith(MockitoExtension.class)
@AllArgsConstructor
@Service
class PlaceAdminImplTest {
    @Mock
    private PlaceRepository placeRepositoryMock;

    @InjectMocks
    private PlaceAdminImpl placeAdmin;

    @Test
    void getPlaces(){
        PlaceEntity placeEntity1 = PlaceEntity.builder().id(0L).name("New York").build();
        PlaceEntity placeEntity2 = PlaceEntity.builder().id(1L).name("Amsterdam").build();

        Place place1 = Place.builder().id(0L).name("New York").build();
        Place place2 = Place.builder().id(1L).name("Amsterdam").build();

        Mockito.when(placeRepositoryMock.findAll()).thenReturn(List.of(placeEntity1, placeEntity2));
        GetPlacesResponse actualResult = placeAdmin.getPlaces();
        GetPlacesResponse expectedResult = GetPlacesResponse.builder().places(List.of(place1, place2)).build();

        assertEquals(expectedResult, actualResult);
        verify(placeRepositoryMock).findAll();
    }
}
