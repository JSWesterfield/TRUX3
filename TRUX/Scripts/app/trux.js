var trux = {
    utilities: {}
    , layout: {}
    , page: {
        handlers: {
        }
        , startUp: null
    }
    , services: {}
    , ui: {}
};

trux.moduleOptions = {
    APPNAME: "truxApp"
        , extraModuleDependencies: []
        , runners: []
        , page: trux.page//we need this object here for later use
};

trux.layout.startUp = function () {

    console.debug("trux.layout.startUp");

    //this does a null check on sabio.page.startUp
    if (trux.page.startUp) {
        console.debug("trux.page.startUp");
        trux.page.startUp();
    }
};

trux.APPNAME = "truxApp";//legacy
$(document).ready(trux.layout.startUp);