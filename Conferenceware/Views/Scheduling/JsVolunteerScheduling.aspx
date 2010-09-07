<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Advanced Volunteer Scheduling
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Advanced Volunteer Scheduling</h2>

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
var initialData = { minsResolution: 60, containerId: "scheduleHolder2", participants: participants, events: events };
// functions

function initialize(data) {
    // build and wire up the page in the container
    var myParticipants = data.participants;
    var myEvents = data.events;
    var target = $("#" + data.containerId);
    if (target.attr('id') != data.containerId) return; // error
    // build table and events
    // build participants area and add accept events for droppable
}

function dateObjectSort(a, b) {
    if (a.date < b.date) return -1;
    if (a.date > b.date) return 1;
    return 0;
}
function getTimeslotStats(timeslots) {
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
    var earliestHour = new Date('23:59');
    var latestHour = new Date('00:00');
    var level = 0;
    for (var tlPos = 0; tlPos < timeline.length; tlPos++) {
        var thisHour = timeline[tlPos].date.getHour();
        if (timeline[tlPos].type == "start") {
            level++;
            maxOverlap = level > maxOverlap ? level : max;
        } else {
            level--;
        }
        if (thisHour < earliestHour.getHour()) {
            earliestHour.setHours(thisHour);
        } else if (thisHour > latestHour.getHour()) {
            latestHour.setHours(thisHour);
        }
    }
    return { firstDate: firstDate, lastDate: lastDate, earliestHour: earliestHour, latestHour: latestHour, maxOverlap: maxOverlap };
    return max;
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
$(function () {
    $(".participant").draggable({
        appendTo: "body",
        helper: "clone"
    });
    $("#event3").droppable({
        activeClass: "ui-state-default",
        hoverClass: "ui-state-hover",
        accept: "#participant1",
        drop: function (event, ui) {
            processAddParticipant($(this), ui.draggable);
        }
    });
    $("#event2").droppable({
        activeClass: "ui-state-default",
        hoverClass: "ui-state-hover",
        accept: "#participant1, #participant2",
        drop: function (event, ui) {
            processAddParticipant($(this), ui.draggable);
        }
    });
    $("#event1").droppable({
        activeClass: "ui-state-default",
        hoverClass: "ui-state-hover",
        accept: "#participant1",
        drop: function (event, ui) {
            processAddParticipant($(this), ui.draggable);
        }
    });
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
