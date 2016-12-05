package hello.controller;

import java.util.List;
import java.util.Random;

import hello.model.User;
import hello.service.PhraseService;
import hello.service.UserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

@RestController
public class HomeController {

    @Autowired
    private UserService userService;

    @Autowired
    private PhraseService phraseService;

    private String generateRandomKey(){
        Random rand = new Random();
        String alph = "abcdefghijklmnopqrstuvwxyz0123456789";
        int n = alph.length();
        String result = "";
        for(int i = 0; i < 5; i++){
            result += alph.charAt(rand.nextInt(n));
        }
        return result;
    }

    //call example "http://localhost:8080/login/name=lavinia&password=lavinia"
    @RequestMapping(value = "/login/{name}&{password}")
    public String loginParams(@PathVariable(name = "name") String name,
                              @PathVariable(name = "password") String password) {
        int existentUser;

        //check in the DB
        User user = userService.findUserByName(name);
        if(user == null) {
            //new user
            userService.saveUser(name, password);
            existentUser = 1;
        } else {
            if(!user.getPassword().equals(password)) {
                //wrong password
                existentUser = 0;
            } else {
                //existing user
                existentUser = 1;
            }
        }

        if(existentUser == 1){
            String key = generateRandomKey();
            //TODO save <key, name> in a map
            return  "yes [" + key + "]";
        } else {
            return "no [wrong password for existing user]";
        }

    }

    @RequestMapping(value = "/getPhrase/{level}&{type}")
    public List<String> getWords(@PathVariable (name = "level") String levelMessage,
                                 @PathVariable(name = "type") String typeMessage) {
        int level = Integer.parseInt(levelMessage);
        int type = Integer.parseInt(typeMessage);
        //we can change the last param that represents the number of returned phrases
        return phraseService.findPhrases(type, level, 25);
    }

    @RequestMapping(value = "/getTop")
    public List<User> getTop() {
        return userService.getTop();
    }

    @RequestMapping(value = "/saveScore/{name}&{score}")
    public void saveScore(@PathVariable (name = "name") String name,
                          @PathVariable (name = "score") String score){
        userService.updateScore(name, score);
    }

    //TODO
//    @RequestMapping(value = "/saveScore/{key}&{score}")
//    public void saveScore(@PathVariable (name = "key") String key,
//                          @PathVariable (name = "score") String score){
//        //get the name from the map with <key, name>
//        userService.updateScore(name, score);
//    }

    //TODO
//    @RequestMapping(value = "/logout/{key")
//    public void logout(@PathVariable (name="key") String key){
//        //remove <key, name> from the map
//    }

}
