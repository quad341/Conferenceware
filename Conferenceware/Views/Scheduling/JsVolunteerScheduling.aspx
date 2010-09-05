<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Advanced Volunteer Scheduling
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Advanced Volunteer Scheduling</h2>

    <div id="scheduleHolder">
        <div id="participants">
            <div class="participant" id="participant1">
                <span class="participantName">John Doe</span><span class="participantEventCount">(0)</span>
                <div class="participantDetails" id="participant1details">
                    <ul class="eventBinding">
                        <li><input type="checkbox" id="participant1event1" /></li>
                        <li><input type="checkbox" id="participant1event2" /></li>
                        <li><input type="checkbox" id="participant1event3" /></li>
                    </ul>
                </div>
            </div>
            <div class="participant" id="participant2">
                <span class="participantName">Jane Smith</span><span class="participantEventCount">(0)</span>
                <div class="participantDetails" id="participant2details">
                    <ul class="eventBinding">
                        <li><input type="checkbox" id="participant2event2" /></li>
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
                <td id="event3">
                    <span class="eventTitle">Event 3</span>
                    <div class="eventNumbers">
                        <span class="current" id="event3current">0</span>
                        (<span class="minimum" id="event3min">1</span>
                        |<span class="ideal" id="event3ideal">1</span>
                        |<span class="maximum" id="event3max">2</span>)
                    </div>
                    <div class="eventDetails" id="event3details">
                        <ul class="eventBinding">
                            <li><input type="checkbox" id="event3participant1" /></li>
                        </ul>
                    </div>
                </td>
                <td class="empty"></td>
            </tr>
            <tr>
                <td id="event1">
                    <span class="eventTitle">Event 1</span>
                    <div class="eventNumbers">
                        <span class="current" id="event1current">0</span>
                        (<span class="minimum" id="event1min">1</span>
                        |<span class="ideal" id="event1ideal">1</span>
                        |<span class="maximum" id="event1max">2</span>)
                    </div>
                    <div class="eventDetails" id="event1details">
                        <ul class="eventBinding">
                            <li><input type="checkbox" id="event1participant1" /></li>
                        </ul>
                    </div>
                </td>
                <td id="event2" rowspan="2">
                    <span class="eventTitle">Event 2</span>
                    <div class="eventNumbers">
                        <span class="current" id="event2current">0</span>
                        (<span class="minimum" id="event2min">1</span>
                        |<span class="ideal" id="event2ideal">1</span>
                        |<span class="maximum" id="event2max">2</span>)
                    </div>
                    <div class="eventDetails" id="event2details">
                        <ul class="eventBinding">
                            <li><input type="checkbox" id="event2participant1" /></li>
                            <li><input type="checkbox" id="event2participant2" /></li>
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
.participant { height: 2em; }
.eventDetails { display: none; }
.participantDetails { display: none; }
#events tr { height: 2em; }
#event td { width: 10em; padding: 0; }
</style>
<script type="text/javascript">
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
                $("#event3current").text($("#event3current").text()++);
            }
        });
        $("#event2").droppable({
            activeClass: "ui-state-default",
            hoverClass: "ui-state-hover",
            accept: "#participant1, #participant2",
            drop: function (event, ui) {
                var who = ui.draggable.attr('id');
                alert(who + " was dropped on " + this.id);
                var currentCount = $('#event2current');
                currentCount.attr('innerHTML', parseInt(currentCount.attr('innerHTML'))+1);
            }
        });
        $("#event1").droppable({
            activeClass: "ui-state-default",
            hoverClass: "ui-state-hover",
            accept: "#participant1",
            drop: function (event, ui) {
                $("#event1current").text($("#event1current").text()++);
            }
        });
    });
</script>
</asp:Content>
