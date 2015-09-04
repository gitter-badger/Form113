//Haut, haut, bas, bas, gauche, droite, gauche, droite, B, A
$("#dialog-message").hide();
var k = [38, 38, 40, 40, 37, 39, 37, 39, 66, 65],
n = 0;
$(document).keydown(function (e) {
    if (e.keyCode === k[n++]) {
        if (n === k.length) {
            $("#dialog-message").show();
            $("#dialog-message").dialog({
                modal: true,
                buttons: {
                    Ok: function () {
                        $(this).dialog("close");
                    }
                }
            });
            n = 0;
            return false;
        }
    }
    else {
        n = 0;
    }
});

$(function () {

    var squares = [],
        SIZE = 3,
        EMPTY = "&nbsp;",
        score,
        moves,
        turn = "X",
    wins = [7, 56, 448, 73, 146, 292, 273, 84],
    startNewGame = function () {
        turn = "X";
        score = { "X": 0, "O": 0 };
        moves = 0;
        squares.forEach(function (square) { square.html(EMPTY); });
    },
    win = function (score) {
        for (var i = 0; i < wins.length; i += 1) {
            if ((wins[i] & score) === wins[i]) {
                return true;
            }
        }
        return false;
    },
    set = function () {

        if ($(this).html() !== EMPTY) {
            return;
        }
        $(this).html(turn);
        console.log($(this));
        moves += 1;
        score[turn] += $(this)[0].indicator;
        console.log(score[turn]);
        if (win(score[turn])) {
            alert(turn + " wins!");
            startNewGame();
        } else if (moves === SIZE * SIZE) {
            alert("Cat\u2019s game!");
            startNewGame();
        } else {
            turn = turn === "X" ? "O" : "X";
        }
    },
    play = function () {
        var board = $("<table border=1 cellspacing=0>"), indicator = 1;
        for (var i = 0; i < SIZE; i += 1) {
            var row = $("<tr>");
            board.append(row);
            for (var j = 0; j < SIZE; j += 1) {
                var cell = $("<td height=50 width=50 align=center valign=center></td>");
                cell[0].indicator = indicator;
                cell.click(set);
                row.append(cell);
                squares.push(cell);
                indicator += indicator;
            }
        }
        $(document.getElementById("tictactoe") || document.body).append(board);
        startNewGame();
    };
    play();
});
