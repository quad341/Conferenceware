<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Advanced Volunteer Scheduling
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Advanced Volunteer Scheduling</h2>

    <div id="scheduleHolder2"></div>
    <div id="scheduleHolder">
        <div id="participants">
            <div class="participant" id="participant1">
                <span class="nowrap"><img class="ui-icon ui-icon-grip-dotted-vertical" alt="dotted vertical grip" src="/Content/img/spacer.gif"/><span class="participantName">John Doe</span><dfn title="Number of slots assigned" class="participantEventCount">(0)</dfn><img class="ui-icon ui-icon-wrench showDetails" alt="Show Details" src="/Content/img/spacer.gif"/></span>
                <div class="details" id="participant1details">
                    <span class="ui-icon ui-icon-squaresmall-close closeDetails"></span>
                    <ul class="eventBinding">
                        <li><input type="checkbox" id="participant1-event1" value="1" /><label>Event 1</label></li>
                        <li><input type="checkbox" id="participant1-event2" value="1" /><label>Event 2</label></li>
                        <li><input type="checkbox" id="participant1-event3" value="1" /><label>Event 3</label></li>
                    </ul>
                </div>
            </div>
            <div class="participant" id="participant2">
                <span class="nowrap"><img class="ui-icon ui-icon-grip-dotted-vertical" alt="dotted vertical grip" src="/Content/img/spacer.gif"/><span class="participantName">Jane Smith</span><dfn title="Number of slots assigned" class="participantEventCount">(0)</dfn><img class="ui-icon ui-icon-wrench showDetails" alt="Show Details" src="/Content/img/spacer.gif"/></span>
                <div class="details" id="participant2details">
                    <span class="ui-icon ui-icon-squaresmall-close closeDetails"></span>
                    <ul class="eventBinding">
                        <li><input type="checkbox" id="participant2-event2" value="1" /><label>Event 2</label></li>
                    </ul>
                </div>
            </div>
        </div>
        <table id="events">
            <tr>
                <th>Time</th>
                <th colspan="2">Friday <small>Oct. 15, 2010</small></th>
                <th colspan="2">Saturday <small>Oct. 16, 2010</small></th>
                <th colspan="2">Sunday <small>Oct. 17, 2010</small></th>
            </tr>
            <tr>
                <td class="time">16:00</td>
                <td class="empty"></td>
                <td class="empty"></td>
                <td class="empty"></td>
                <td class="empty"></td>
                <td class="empty"></td>
                <td class="empty"></td>
            </tr>
            <tr>
                <td class="time">17:00</td>
                <td class="empty"></td>
                <td class="empty"></td>
                <td class="empty"></td>
                <td class="empty"></td>
                <td class="event" id="event3">
                    <span class="nowrap"><span class="eventTitle">Event 3</span><img class="ui-icon ui-icon-wrench showDetails" alt="Show Details" src="/Content/img/spacer.gif"/></span>
                    <div class="eventNumbers">
                        <dfn title="Number of assignees" class="current" id="event3current">0</dfn>
                        (<dfn title="Mimimum number of assignees" class="minimum" id="event3min">1</dfn>
                        |<dfn title="Ideal number of assignees" class="ideal" id="event3ideal">1</dfn>
                        |<dfn title="Maximum number of assignees" class="maximum" id="event3max">2</dfn>)
                    </div>
                    <div class="details" id="event3details">
                        <span class="ui-icon ui-icon-squaresmall-close closeDetails"></span>
                        <ul class="eventBinding">
                            <li><input type="checkbox" id="event3-participant1" value="1" /><label>John Doe</label></li>
                        </ul>
                    </div>
                </td>
                <td class="empty"></td>
            </tr>
            <tr>
                <td class="time">18:00</td>
                <td class="event" id="event1">
                    <span class="nowrap"><span class="eventTitle">Event 1</span><img class="ui-icon ui-icon-wrench showDetails" alt="Show Details" src="/Content/img/spacer.gif"/></span>
                    <div class="eventNumbers">
                        <dfn title="Number of assignees" class="current" id="event1current">0</dfn>
                        (<dfn title="Mimimum number of assignees" class="minimum" id="event1min">1</dfn>
                        |<dfn title="Ideal number of assignees" class="ideal" id="event1ideal">1</dfn>
                        |<dfn title="Maximum number of assignees" class="maximum" id="event1max">2</dfn>)
                    </div>
                    <div class="details" id="event1details">
                        <span class="ui-icon ui-icon-squaresmall-close closeDetails"></span>
                        <ul class="eventBinding">
                            <li><input type="checkbox" id="event1-participant1" value="1" /><label>John Doe</label></li>
                        </ul>
                    </div>
                </td>
                <td class="event" id="event2" rowspan="2">
                    <span class="nowrap"><span class="eventTitle">Event 2</span><img class="ui-icon ui-icon-wrench showDetails" alt="Show Details" src="/Content/img/spacer.gif"/></span>
                    <div class="eventNumbers">
                        <dfn title="Number of assignees" class="current" id="event2current">0</dfn>
                        (<dfn title="Mimimum number of assignees" class="minimum" id="event2min">1</dfn>
                        |<dfn title="Ideal number of assignees" class="ideal" id="event2ideal">1</dfn>
                        |<dfn title="Maximum number of assignees" class="maximum" id="event2max">2</dfn>)
                    </div>
                    <div class="details" id="event2details">
                        <span class="ui-icon ui-icon-squaresmall-close closeDetails"></span>
                        <ul class="eventBinding">
                            <li><input type="checkbox" id="event2-participant1" value="1" /><label>John Doe</label></li>
                            <li><input type="checkbox" id="event2-participant2" value="1" /><label>Jane Smith</label></li>
                        </ul>
                    </div>
                </td>
                <td class="empty"></td>
                <td class="empty"></td>
                <td class="empty"></td>
                <td class="empty"></td>
            </tr>
            <tr>
                <td class="time">19:00</td>
                <td class="empty"></td>
                <!-- rowspan event2 -->
                <td class="empty"></td>
                <td class="empty"></td>
                <td class="empty"></td>
                <td class="empty"></td>
            </tr>
            <tr>
                <td class="time">20:00</td>
                <td class="empty"></td>
                <td class="empty"></td>
                <td class="empty"></td>
                <td class="empty"></td>
                <td class="empty"></td>
                <td class="empty"></td>
            </tr>
            <tr>
                <td class="time">21:00</td>
                <td class="empty"></td>
                <td class="empty"></td>
                <td class="empty"></td>
                <td class="empty"></td>
                <td class="empty"></td>
                <td class="empty"></td>
            </tr>
        </table>
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ExtraHeadContent" runat="server">
<style type="text/css">
.time { font-weight: bold; }
#participants { float: left; padding-right: 2em; }
#events { float: left; width: auto; }
.participant { clear: both; border: 1px solid #888; background-color: #ccc; margin-bottom: .2em; }
.nowrap { white-space: nowrap; }
.details { display: none; }
.closeDetails { display: block; float: left; }
.eventBinding { float: left; }
#events tr { height: 2em; }
#event td { width: 10em; padding: 0; }
.minNotHit { background-color: Red; }
.minHit { background-color: Yellow; }
.idealHit { background-color: Green; }
.maxHit { background-color: Blue; }
img.ui-icon { display: inline; width: 16px; height: 16px; }
</style>
<script type="text/javascript">
// static test data
// participants
    var participants = new Array();
    participants[1] = { name: "John Doe", id: 1, allowEvents: [1, 2, 3] };
    participants[2] = { name: "Jane Smith", id: 2, allowEvents: [2] };
// events is static testing data already parsed for the static html
var events = new Array();
events[1] = { title: "Event 1", id: 1, start: new Date('Oct. 15 2010 18:00'), end: new Date('Oct. 15 2010 19:00'), current: 0, min: 1, ideal: 1, max: 2, participants: new Array(), lastStatus: null, status: null };
events[2] = { title: "Event 2", id: 2, start: new Date('Oct. 15 2010 18:00'), end: new Date('Oct. 15 2010 20:00'), current: 0, min: 1, ideal: 1, max: 2, participants: [1], lastStatus: null, status: null };
events[3] = { title: "Event 3", id: 3, start: new Date('Oct. 17 2010 17:00'), end: new Date('Oct. 17 2010 18:00'), current: 0, min: 1, ideal: 1, max: 2, participants: new Array(), lastStatus: null, status: null };
// put it all together
var initialData = { minsResolution: 60, containerId: "scheduleHolder2" /* this won't be used; it will be an each statment */, participants: participants, events: events };
// functions

function initialize(data) {
    // constants
    var MILISECONDS_IN_ONE_DAY = 86400000;
    var MILISECONDS_IN_ONE_MINUTE = 60000;
    var SPACER_SRC = data.spacerSrc ? data.spacerSrc : "/Content/img/spacer.gif";
    // build and wire up the page in the container
    var myParticipants = data.participants;
    var myEvents = data.events;
    var target = $("#" + data.containerId).first();
    if (target.attr('id') != data.containerId) return; // error
    var resolution = getAcceptableResolution(data.minsResolution);
    // we really only care about effective times for events
    // we can't assume that the array is 0 indexed
    for (var index in myEvents) {
        myEvents[index].start = getEffectiveTime(myEvents[index].start);
        myEvents[index].end = getEffectiveTime(myEvents[index].end);
    }
    // build table and events
    var eventsData = getTimeStats(myEvents);
    if (null == eventsData) return; // error
    var numDays = Math.ceil((eventsData.lastDate - eventsData.firstDate) / MILISECONDS_IN_ONE_DAY);
    var numSlots = (eventsData.latestHour - eventsData.earliestHour) * 60 / resolution;
    if (numSlots < 1) return; // error
    // we'll compute the table in a matrix that is numDays*eventsData.maxOverlap columns (to ensure enough columns for all the events on each day)
    //    and numSlots rows and just use row spans if something takes more than 1 slot
    var cols = numDays*eventsData.maxOverlap;
    var eventsMatrix = new Array(cols);
    // we initialize everything to objects with no element and a status of empty
    //   we will use the status of element to indicate an element is present
    //   and a status of taken to imply the entry is in use by an spanned event above
    // first column is time for the slot; top slot is the heading
    for (var colNum = 0; colNum < cols + 1; colNum++) {
        eventsMatrix[colNum] = new Array(numSlots + 1);
        for (var rowNum = 0; rowNum < numSlots + 1; rowNum++) {
            if (rowNum == 0) {
                // headings
                if (colNum == 0) eventsMatrix[0][0] = { status: "element", element: $.create("<th/>", { text: "Time" }) };
                else {
                    // TODO: figure out how to determine dates easily
                    eventsMatrix[colIdx][0] = { status: "element", element: $.create("<th/>", { colspan: eventsData.maxOverlap, text: "TODO Day" }) };
                }
            }
            else if (colNum == 0) {
                // TODO: figure out timeslot start time
                eventsMatrix[0][rowNum] = { status: "element", element: $.create("<td/>", { "class": "time", text: "TODO time" }) };
            } else
                eventsMatrix[colNum][rowNum] = { status: "empty", element: null };
        }
    }
    // insert the events into the matrix
    for (var index in myEvents) {
        var thisDate = new Date(myEvents[index].start.getYears(), myEvents[index].start.getMonths(), myEvents[index].start.getDate());
        var dateOffset = Math.ceil((thisDate - eventsData.firstDate) / MILISECONDS_IN_ONE_DAY) * eventsData.maxOverlap;
        var totalNeededSpots = Math.ceil((myEvents[index].end - myEvents[index].start) / MILISECONDS_IN_ONE_MINUTE);
        var slotOffset = (((myEvents[index].start.getHours() - eventsData.earliestHour) * 60) + myEvents[index].start.getMinutes()) / resolution;
        var goodToInsert = false;
        for (var colIdx = dateOffset; colIdx <= dateOffset + eventsData.maxOverlap; colIdx++) {
            for (var slotIdx = slotOffset; slotIdx < slotOffset + totalNeededSpots; slotIdx++) {
                if (eventsMatrix[colIdx][slotIdx].status != "empty")
                    break;
                if (slotIdx == slotOffset + totalNeededSpots - 1)
                    goodToInsert = true;
            }
            if (goodToInsert) {
                var eid = myEvents[index].id;
                var elem = $.create("<td/>", {
                    rowspan: totalNeededSpots,
                    "class": "event",
                    id: "event" + eid
                });
                var nowrap = $.create("<span/>", { "class": "nowrap" });
                $.create("<span/>", {
                    "class": "eventTitle",
                    text: myEvents[index].title
                }).appendTo(nowrap);
                $.create("<img/>", {
                    "class": "ui-icon ui-icon-wrench showDetails",
                    alt: "Show Details",
                    src: SPACER_SRC
                }).appendTo(nowrap);
                var eventNumbers = $.create("<div/>", { "class": "eventNumbers" });
                eventNumbers.attr("innerHTML", '<dfn title="Number of assignees" class="current" id="event' + eid + 'current">0</dfn>' +
                        '(<dfn title="Mimimum number of assignees" class="minimum" id="event' + eid + 'min">' + myEvents[index].min + '</dfn>' +
                        '|<dfn title="Ideal number of assignees" class="ideal" id="event' + eid + 'ideal">' + myEvents[index].ideal + '</dfn>' +
                        '|<dfn title="Maximum number of assignees" class="maximum" id="event' + eid + 'max">' + myEvents[index].max + '</dfn>)');
                eventNumbers.appendTo(elem);
                var eventDetails = $.create("<div/>", { "class": "details", id: "event" + eid + "details" });
                eventDetails.attr("innerHTML", '<span class="ui-icon ui-icon-squaresmall-close closeDetails"></span>' +
                        '<ul class="eventBinding">' +
                        '</ul>');
                eventDetails.appendTo(elem);
                elem.droppable({
                    activeclass: "ui-state-default",
                    hoverclass: "ui-state-hover",
                    accept: "",
                    drop: function (event, ui) {
                        processAddParticipant($(this), ui.draggable);
                    }
                });
                eventsMatrix[colIdx][slotOffset] = { status: "element", element: elem };
                for (var additionalIdx = slotOffset + 1; additionalIdx < slotOffset + totalNeededSpots; additionalIdx++) {
                    eventsMatrix[colIdx][additionalIdx] = { status: "taken", element: null };
                }
            } // end if (goodToInsert)
        } // end for ... colIdx ...
    } // end for index in myEvents
    // matrix should be built; build table
    var table = $.create("<table/>", { id: "events" });
    for (var slotIdx = 0; slotIdx < numSlots; slotIdx++) {
        var row = $.create("<tr/>");
        for (var colIdx = 0; colIdx < cols; colIdx++) {
            if (eventsMatrix[colIdx][slotIdx].status == "empty") {
                $.create('<td class="empty"></td>').appendTo(row);
            } else if (eventsMatrix[colIdx][slotIdx].status == "element") {
                eventsMatrix[colIdx][slotIdx].element.appendTo(row);
            }
            // else if (eventsMatrix[colIdx][slotIdx].status == "taken") { /* do nothing */ }
        }
        row.appendTo(table);
    }
    // table is built
    // build participants area and add accept events for droppables
    var participantsDiv = $.create("<div/>", { id: "participants" });
    // add divs for each participant
    for (var partIdx in myParticipants) {
        var pid = myParticipants[partIdx].id;
        var container = $.create("<div/>", { "class": "participant", id: "participant" + pid });
        var nowrap = $.create("<span/>", { "class": "nowrap" });
        $.create("<img/>", { "class": "ui-icon ui-icon-grip-dotted-vertical", alt: "dotted vertical grip", src: SPACER_SRC }).appendTo(nowrap);
        $.create("<span/>", { "class": "participantName", text: myParticipants[partIdx].name }).appendTo(nowrap);
        $.create("<dfn/>", { "class": "participantEventCount", title: "Number of slots assigned", text: "(0)" }).appendTo(nowrap);
        $.create("<img/>", { "class": "ui-icon ui-icon-wrench showDetails", alt: "Show Details", src: SPACER_SRC }).appendTo(nowrap);
        nowrap.appendTo(container);
        var details = $.create("<div/>", { "class": "details", id: "participant" + pid + "details" });
        $.create("<span/>", { "class": "ui-icon ui-icon-squaresmall-close closeDetails" }).appendTo(details);
        var eventBinding = $.create("<ul/>", { "class": "eventBinding" });
        // this is where we add the checkboxes to both the event and the list
        //   because of how the generic selectors work, we only have to update droppable here
        $.each(myParticipants[partIdx].allowEvents, function (i, v) {
            var event = $("#event" + v, table).first();
            var li = $.create("<li/>");
            $.create("<input/>", { type: "checkbox", id: "participant" + pid + "-event" + v, value: "1" }).appendTo(li);
            $.create("<label/>", { text: $(".eventTitle", event).text() }).appendTo(li); // easier than trying to consult data since there is no correlation between id an index
            li.appendTo(eventBinding);
            var eventLi = $.create("<li/>");
            $.create("<input/>", { type: "checkbox", id: "event" + v + "-participant" + pid, value: "1" }).appendTo(eventLi);
            $.create("<label/>", { text: myParticipants[partIdx].name }).appendTo(eventLi);
            eventLi.appendTo($(".eventBinding", event).first());
            //getter
            var accept = event.droppable("option", "accept");
            accept = accept == "" ? "#participant" + pid : accept + ", #participant" + pid;
            event.droppable("option", "accept", accept);
        });
        eventBinding.appendTo(details);
        details.appendTo(container);
        container.appendTo(participantsDiv);
    }
    // participantsDiv has been created
    participantsDiv.appendTo(target);
    table.appendTo(target);
    // the initializing code should do the rest
}

function getAcceptableResolution(baseMins) {
    // we only allow .25, .5, 1, 2 * 60 increments
    if (baseMins == 15
        || baseMins == 30
        || baseMins == 60
        || baseMins == 120)
        return baseMins;
    // default to 60
    return 60;
}

// rounds time based on resolution; returns a clone of the date
//    with the proper hour/minutes set
//    this function only considers to the minute resolution
function getEffectiveTime(resolution, realTime) {
    var timeClone = $.extend({}, realTime);
    timeClone.setSeconds(0); // since we do not consider seconds, this makes math more int-y
    var minutes = timeClone.getMinutes();
    var hours = timeClone.getHours();
    switch (resolution) {
        case 15:
            if (minutes < 8)
                timeClone.setMinutes(0);
            else if (minutes < 23)
                timeClone.setMinutes(15);
            else if (minutes < 38)
                timeClone.setMinutes(30);
            else if (minutes < 53)
                timeClone.setMinutes(45);
            else {
                timeClone.setMinutes(0);
                timeClone.setHours(hours + 1);
            }
            break;
        case 30:
            if (minutes < 15)
                timeClone.setMinutes(0);
            else if (minutes < 45)
                timeClone.setMinutes(30);
            else {
                timeClone.setMinutes(0);
                timeClone.setHours(hours + 1);
            }
            break;
        case 60:
            timeClone.setMinutes(0);
            if (minutes >= 30)
                timeClone.setHours(hours + 1);
            break;
        case 120:
            timeClone.setMinutes(0);
            if (hours % 2 == 1)
                timeClone.setHours(hours + 1);
            break;
    }
    return timeClone;
}

function dateObjectSort(a, b) {
    if (a.date < b.date) return -1;
    if (a.date > b.date) return 1;
    return 0;
}
function getTimeslotStats(timeslots) {
    if (timeslots.length < 1) return null;
    var timeline = new Array();
    for (var i = 0; i < timeslots.length; i++) {
        timeline.push({ type: "start", date: timeslots[i].start });
        timeslot.push({ type: "end", date: timeslots[i].end });
    }
    timeline.sort(dateObjectSort);
    var firstDate = new Date(timeline[0].getFullYear(), timeline[0].getMonth(), timeline[0].getDate());
    var lastIdx = timeline.length - 1;
    var lastDate = new Date(timeline[lastIdx].getFullYear(), timeline[lastIdx].getMonth(), timeline[lastIdx].getDate());
    var maxOverlap = 0;
    var earliestHour = 24;
    var latestHour = -1;
    var level = 0;
    for (var tlPos = 0; tlPos < timeline.length; tlPos++) {
        var thisHour = timeline[tlPos].date.getHour();
        if (timeline[tlPos].type == "start") {
            level++;
            maxOverlap = level > maxOverlap ? level : max;
        } else {
            level--;
        }
        if (thisHour < earliestHour) {
            earliestHour = thisHour;
        } else if (thisHour > latestHour.getHour()) {
            var offset = timeline[tlPos].date.getMinute() > 0 ? 1 : 0;
            latestHour = thisHour + offset;
        }
    }
    return { firstDate: firstDate, lastDate: lastDate, earliestHour: earliestHour, latestHour: latestHour, maxOverlap: maxOverlap };
}
function updateStatus(eventEntry) {
    eventEntry.lastStatus = eventEntry.status;
    eventEntry.status = "minNotHit";
    if (eventEntry.current >= eventEntry.min)
        eventEntry.status = "minHit";
    if (eventEntry.current >= eventEntry.ideal)
        eventEntry.status = "idealHit";
    if (eventEntry.current >= eventEntry.max)
        eventEntry.status = "maxHit";
    if (eventEntry.status != eventEntry.lastStatus) {
        var id = "#event" + eventEntry.id;
        $(id).removeClass(eventEntry.lastStatus);
        $(id).addClass(eventEntry.status);
    }
}
function processAddParticipant(event, participant, ignoreArray) {
    if (ignoreArray == null) force = false;
    var participantCheckboxId = "#" + participant.attr("id") + "-" + event.attr("id");
    var eventCheckboxId = "#" + event.attr("id") + "-" + participant.attr("id");
    $(participantCheckboxId).attr('checked', true);
    $(eventCheckboxId).attr('checked', true);

    var eventId = parseInt(event.attr("id").substring(5)); //event is 5 characters
    if (!ignoreArray && $.inArray(parseInt(participant.attr("id").substring(11)), events[eventId].participants) != -1) //"participant" is 11 characters
        return;
    events[eventId].current++;
    if(!ignoreArray) events[eventId].participants.push(parseInt(participant.attr("id").substring(11))); //"participant" is 11 characters
    var participantCounter = participant.children().first().children('.participantEventCount').first();
    participantCounter.text("(" + (parseInt(participantCounter.text().substring(1, participantCounter.text().length-1)) + 1) + ")"); // pull out the middle
    var eventCounter = event.children(".eventNumbers").first().children(".current").first();
    eventCounter.text(parseInt(eventCounter.text())+1);
    updateStatus(events[eventId]);
    event.droppable("option", "disabled", false);
    if (events[eventId].status == "maxHit") {
        event.droppable("option", "disabled", true);
    }
}

function processRemoveParticipant(event, participant) {
    var participantCheckboxId = "#" + participant.attr("id") + "-" + event.attr("id");
    var eventCheckboxId = "#" + event.attr("id") + "-" + participant.attr("id");
    $(participantCheckboxId).attr('checked', false);
    $(eventCheckboxId).attr('checked', false);

    var eventId = parseInt(event.attr("id").substring(5)); //event is 5 characters
    var i;
    if ((i = $.inArray(parseInt(participant.attr("id").substring(11)), events[eventId].participants)) == -1) //"participant" is 11 characters
        return;
    events[eventId].current--;
    events[eventId].participants.splice(i, 1);
    var participantCounter = participant.children().first().children('.participantEventCount').first();
    participantCounter.text("(" + (parseInt(participantCounter.text().substring(1, participantCounter.text().length - 1)) - 1) + ")"); // pull out the middle
    var eventCounter = event.children(".eventNumbers").first().children(".current").first();
    eventCounter.text(parseInt(eventCounter.text()) - 1);
    updateStatus(events[eventId]);
    event.droppable("option", "disabled", false);
}

function processEventCheck(checkbox) {
    var ids = checkbox.attr("id").split("-");
    if (checkbox.attr("checked")) {
        processAddParticipant($("#" + ids[0]).first(), $("#" + ids[1]).first());
    }
    else {
        processRemoveParticipant($("#" + ids[0]).first(), $("#" + ids[1]).first());
    }
}

function processParticipantCheck(checkbox) {
    var ids = checkbox.attr("id").split("-");
    if (checkbox.attr("checked")) {
        processAddParticipant($("#" + ids[1]).first(), $("#" + ids[0]).first()); ;
    }
    else {
        processRemoveParticipant($("#" + ids[1]).first(), $("#" + ids[0]).first());
    }
}
initialize(initialData);
$(function () {
    $(".participant").draggable({
        appendTo: "body",
        helper: "clone"
    });
    /*$("#event3").droppable({
        active"class": "ui-state-default",
        hover"class": "ui-state-hover",
        accept: "#participant1",
        drop: function (event, ui) {
            processAddParticipant($(this), ui.draggable);
        }
    });
    $("#event2").droppable({
        active"class": "ui-state-default",
        hover"class": "ui-state-hover",
        accept: "#participant1, #participant2",
        drop: function (event, ui) {
            processAddParticipant($(this), ui.draggable);
        }
    });
    $("#event1").droppable({
        active"class": "ui-state-default",
        hover"class": "ui-state-hover",
        accept: "#participant1",
        drop: function (event, ui) {
            processAddParticipant($(this), ui.draggable);
        }
    });*/
    $(".showDetails").click(function () { $(this).parent().parent().children(".details").show(); });
    $(".closeDetails").click(function () { $(this).parent().hide(); });
    $(".participant input:checkbox").click(function () { processParticipantCheck($(this)); });
    $(".event input:checkbox").click(function () { processEventCheck($(this)); });
    $(".event").each(function (i, e) { updateStatus(events[parseInt($(e).attr("id").substring(5))]); });
    for(var i in events) {
        if (events[i].participants.length > 0) {
            for (var pIdx = 0; pIdx < events[i].participants.length; pIdx++) { 
                processAddParticipant($("#event" + events[i].id).first(), $("#participant" + events[i].participants[pIdx]).first(), true);
            }
        }
    }
});

</script>
</asp:Content>
