<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Advanced Volunteer Scheduling
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Advanced Volunteer Scheduling</h2>

    <div id="scheduleHolder">
        <div id="participants">
            <div class="participant" id="participant1">
                <span class="participantTitle"><span class="ui-icon ui-icon-grip-dotted-vertical"></span><span class="participantName">John Doe</span><span class="participantEventCount">(0)</span><span class="ui-icon ui-icon-wrench showDetails"></span></span>
                <div class="participantDetails" id="participant1details">
                    <span class="ui-icon ui-icon-squaresmall-close closeDetails"></span>
                    <ul class="eventBinding">
                        <li><input type="checkbox" id="participant1event1" value="1" /><label>Event 1</label></li>
                        <li><input type="checkbox" id="participant1event2" value="1" /><label>Event 2</label></li>
                        <li><input type="checkbox" id="participant1event3" value="1" /><label>Event 3</label></li>
                    </ul>
                </div>
            </div>
            <div class="participant" id="participant2">
                <span class="participantTitle"><span class="ui-icon ui-icon-grip-dotted-vertical"></span><span class="participantName">Jane Smith</span><span class="participantEventCount">(0)</span><span class="ui-icon ui-icon-wrench showDetails"></span></span>
                <div class="participantDetails" id="participant2details">
                    <span class="ui-icon ui-icon-squaresmall-close closeDetails"></span>
                    <ul class="eventBinding">
                        <li><input type="checkbox" id="participant2event2" value="1" /><label>Event 2</label></li>
                    </ul>
                </div>
            </div>
        </div>
        <table id="events">
            <tr>
                <th colspan="2">Friday</th>
                <th colspan="2">Saturday</th>
                <th colspan="2">Sunday</th>
            </tr>
            <tr>
                <td class="empty"></td>
                <td class="empty"></td>
                <td class="empty"></td>
                <td class="empty"></td>
                <td class="empty"></td>
                <td class="empty"></td>
            </tr>
            <tr>
                <td class="empty"></td>
                <td class="empty"></td>
                <td class="empty"></td>
                <td class="empty"></td>
                <td class="event" id="event3">
                    <span class="eventTitle">Event 3</span>
                    <div class="eventNumbers">
                        <span class="current" id="event3current">0</span>
                        (<span class="minimum" id="event3min">1</span>
                        |<span class="ideal" id="event3ideal">1</span>
                        |<span class="maximum" id="event3max">2</span>)
                    </div>
                    <div class="eventDetails" id="event3details">
                        <ul class="eventBinding">
                            <li><input type="checkbox" id="event3participant1" value="1" /></li>
                        </ul>
                    </div>
                </td>
                <td class="empty"></td>
            </tr>
            <tr>
                <td class="event" id="event1">
                    <span class="eventTitle">Event 1</span>
                    <div class="eventNumbers">
                        <span class="current" id="event1current">0</span>
                        (<span class="minimum" id="event1min">1</span>
                        |<span class="ideal" id="event1ideal">1</span>
                        |<span class="maximum" id="event1max">2</span>)
                    </div>
                    <div class="eventDetails" id="event1details">
                        <ul class="eventBinding">
                            <li><input type="checkbox" id="event1participant1" value="1" /></li>
                        </ul>
                    </div>
                </td>
                <td class="event" id="event2" rowspan="2">
                    <span class="eventTitle">Event 2</span>
                    <div class="eventNumbers">
                        <span class="current" id="event2current">0</span>
                        (<span class="minimum" id="event2min">1</span>
                        |<span class="ideal" id="event2ideal">1</span>
                        |<span class="maximum" id="event2max">2</span>)
                    </div>
                    <div class="eventDetails" id="event2details">
                        <ul class="eventBinding">
                            <li><input type="checkbox" id="event2participant1" value="1" /></li>
                            <li><input type="checkbox" id="event2participant2" value="1" /></li>
                        </ul>
                    </div>
                </td>
                <td class="empty"></td>
                <td class="empty"></td>
                <td class="empty"></td>
                <td class="empty"></td>
            </tr>
            <tr>
                <td class="empty"></td>
                <!-- rowspan event2 -->
                <td class="empty"></td>
                <td class="empty"></td>
                <td class="empty"></td>
                <td class="empty"></td>
            </tr>
            <tr>
                <td class="empty"></td>
                <td class="empty"></td>
                <td class="empty"></td>
                <td class="empty"></td>
                <td class="empty"></td>
                <td class="empty"></td>
            </tr>
            <tr>
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
#participants { float: left; padding-right: 2em; }
#events { float: left; width: auto; }
.participant { clear: both; }
.participantTitle { white-space: nowrap; }
.eventDetails { display: none; }
.participantDetails { display: none; }
.closeDetails { display: block; float: left; }
.eventBinding { float: left; }
#events tr { height: 2em; }
#event td { width: 10em; padding: 0; }
.minNotHit { background-color: Red; }
.minHit { background-color: Yellow; }
.idealHit { background-color: Green; }
.maxHit { background-color: Blue; }
</style>
<script type="text/javascript">
var events = new Array();
events[1] = { title:"Event 1", id: 1, current: 0, min: 1, ideal: 1, max: 2, participants: new Array(), lastStatus: "minNotHit", status: "minNotHit" };
events[2] = { title: "Event 2", id: 2, current: 0, min: 1, ideal: 1, max: 2, participants: new Array(), lastStatus: "minNotHit", status: "minNotHit" };
events[3] = { title: "Event 3", id: 3, current: 0, min: 1, ideal: 1, max: 2, participants: new Array(), lastStatus: "minNotHit", status: "minNotHit" };
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
function processAddParticipant(event, participant) {
    var participantCheckboxId = "#" + participant.attr("id") + event.attr("id");
    var eventCheckboxId = "#" + event.attr("id") + participant.attr("id");
    $(participantCheckboxId).attr('checked', true);
    $(eventCheckboxId).attr('checked', true);

    var eventId = parseInt(event.attr("id").substring(5));
    if (jQuery.inArray(participant.attr("id"), events[eventId].participants) != -1)
        return;
    events[eventId].current++;
    events[eventId].participants.push(participant.attr("id"));
    var participantCounter = participant.children().first().children('.participantEventCount').first();
    participantCounter.text("(" + (parseInt(participantCounter.text().substring(1, 2)) + 1) + ")");
    var eventCounter = event.children(".eventNumbers").first().children(".current").first();
    eventCounter.text(parseInt(eventCounter.text())+1);
    updateStatus(events[eventId]);
    event.droppable("option", "disabled", false);
    if (events[eventId].status == "maxHit") {
        event.droppable("option", "disabled", true);
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
    $(".showDetails").click(function () { $(this).parent().parent().children(".participantDetails").show(); });
    $(".closeDetails").click(function () { $(this).parent().hide(); });
});
$(".event").each(function (i, e) { updateStatus(events[parseInt(e.attr("id").substring(5))]); });
</script>
</asp:Content>
