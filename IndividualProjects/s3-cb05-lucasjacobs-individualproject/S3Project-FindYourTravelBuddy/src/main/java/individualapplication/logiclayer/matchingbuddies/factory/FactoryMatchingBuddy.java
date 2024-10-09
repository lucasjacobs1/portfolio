package individualapplication.logiclayer.matchingbuddies.factory;

import individualapplication.logiclayer.matchingbuddies.algorithms.BasicMatchingAlgorithm;
import individualapplication.logiclayer.matchingbuddies.algorithms.StandardMatchAlgorithm;
import individualapplication.logiclayer.matchingbuddies.algorithms.NoPreferenceMatchingAlgorithm;
import individualapplication.logiclayer.matchingbuddies.MatchAlgorithms;

public class FactoryMatchingBuddy {
    private FactoryMatchingBuddy(){}
    public static MatchAlgorithms returnMatchAlgorithm(int algorithmId){
        MatchAlgorithms matchAlgorithms;
        switch (algorithmId){
            case 0:
                matchAlgorithms = new BasicMatchingAlgorithm();
                break;
            case 1:
                matchAlgorithms = new StandardMatchAlgorithm();
                break;
            case 2:
                matchAlgorithms = new NoPreferenceMatchingAlgorithm();
                break;
            default: throw new IllegalArgumentException("this should not happen");
        }
        return matchAlgorithms;
    }
}
